using Palworld.RESTSharp.ProxyServer;


namespace Palworld.RESTSharp.Client
{
    public partial class FormChangePassword : Form
    {
        User _proxyUser;
        internal string newPassword;

        public FormChangePassword()
        {
            InitializeComponent();

        }

        public void ShowDialog(User proxyUser)
        {
            _proxyUser = proxyUser;
            this.StartPosition = FormStartPosition.CenterParent;
            base.ShowDialog();
        }

        private void btnUpdatePassword_Click(object sender, EventArgs e)
        {
            if (txtCurrentPassword.Text == _proxyUser.Password)
            {
                newPassword = txtNewPassword.Text;
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Password does not match current password.", "Incorrect Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormChangePassword_Load(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            DialogResult = DialogResult.Cancel;
        }
    }
}
