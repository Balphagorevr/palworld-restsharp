/*
TABLE: TABLE_USERS
BEGIN; 
CREATE TABLE [Users] 
(
    [Username] nvarchar(128) NULL COLLATE NOCASE, 
    [Token] nvarchar(128) NULL COLLATE NOCASE, 
    [Enabled] bit NULL
); 

CREATE UNIQUE INDEX [idx_UserConst] ON [Users] ([Username] ASC); COMMIT;";

 */
using Dapper;
using Palworld.RESTSharp.Common;
using System.Data.SQLite;

namespace Palworld.RESTSharp.ProxyService.Database.SQLite
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseConfiguration dbConfig;

        public string TableName { get => "Users"; set { } }
        public string TableColumns { get => "Username, Token, Enabled, Roles, IsDeleted"; set { } }

        public UserRepository()
        {
        
        }

        public UserRepository(DatabaseConfiguration databaseConfig)
        {
            dbConfig = databaseConfig;
            SqlMapper.AddTypeHandler(new StringArrayTypeHandler());
        }

        public async Task CreateTable(SQLiteConnection connection, DatabaseConfiguration dbConfig)
        {
            // How to get DB config here?

            string createTable = $"BEGIN; CREATE TABLE [{TableName}] ([Username] nvarchar(128) NULL COLLATE NOCASE, [Token] nvarchar(128) NULL COLLATE NOCASE, [Enabled] bit NULL, [Roles] nvarchar(128) NOT NULL, [IsDeleted] BIT NOT NULL DEFAULT 0); CREATE UNIQUE INDEX [idx_UserConst] ON [{TableName}] ([Username] ASC); COMMIT;";

            await connection.ExecuteAsync(createTable);

            // Setup default user account.
            if (dbConfig.Options.TryGetValue("InitialUserToken", out string? token) && !String.IsNullOrEmpty(token))
            {
                UserRepository userRepositoryCreate = new UserRepository(dbConfig);

                await userRepositoryCreate.Add(new User()
                {
                    UserName = "Admin",
                    Token = token,
                    Roles = ["Owner", "Admin"],
                    Enabled = true
                });

                Console.WriteLine("Created default user account with token as the server admin password provided in configuration.");
            }
            else
            {
                throw new Exception("InitialUserToken not found or empty in configuration.");
            }
        }

        public async Task<int> Add(User user)
        {
            using var connection = new SQLiteConnection(dbConfig.ConnectionString);
            //if (this.Get(user) != null) { throw new Exception("User already exists."); }

            return await connection.ExecuteScalarAsync<int>($"INSERT INTO {TableName}({TableColumns}) VALUES (@UserName, @Token, @Enabled, @Roles, 0); SELECT last_insert_rowid()", user);
        }

        public async Task<bool> Delete(int ID)
        {
            using var connection = new SQLiteConnection(dbConfig.ConnectionString);
            return await connection.ExecuteAsync($"UPDATE {TableName} SET IsDeleted = 1 WHERE rowid = @ID AND IsDeleted = 0", new { ID }) == 1 ? true : false;
        }

        public async Task<User> Get(int ID)
        {
            using var connection = new SQLiteConnection(dbConfig.ConnectionString);

            return await connection.QueryFirstOrDefaultAsync<User>($"SELECT rowid AS ID, * FROM {TableName} WHERE rowid = @ID AND IsDeleted = 0", new { ID });
        }

        public async Task<User> Get(User user)
        {
            using var connection = new SQLiteConnection(dbConfig.ConnectionString);

            return await connection.QueryFirstOrDefaultAsync<User>($"SELECT rowid AS ID, * FROM {TableName} WHERE (Token = @Token OR rowid = @ID) AND IsDeleted = 0", user);
        }

        public async Task<IEnumerable<User>> Get()
        {
            using var connection = new SQLiteConnection(dbConfig.ConnectionString);

            var users = await connection.QueryAsync<User>($"SELECT rowid AS ID, * FROM {TableName} WHERE IsDeleted = 0");

            return users;
        }

        public async Task<bool> UpdateUser(User user)
        {
            using var connection = new SQLiteConnection(dbConfig.ConnectionString);
            bool updated = await connection.ExecuteAsync($"UPDATE {TableName} SET UserName = @UserName, Token = @Token, Enabled = @Enabled, Roles = @Roles WHERE (rowid = @ID OR Token = @Token) AND IsDeleted = 0", user) == 1 ? true : false;

            return updated;
        }
    }
}
