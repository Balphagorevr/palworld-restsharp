using System;

namespace Palworld.RESTSharp.ProxyServer
{
    /// <summary>
    /// Represents an audit entry for a user.
    /// </summary>
    public class UserAudit
    {
        /// <summary>
        /// Date/Time the entry was made.
        /// </summary>
        public DateTime AuditDate { get; set; }
        /// <summary>
        /// User ID of the user who made the entry.
        /// </summary>
        public int AuditUserID { get; set; }
        /// <summary>
        /// The username of the user who made the entry.
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// The type of audit event.
        /// </summary>
        public AuditEventType AuditEvent { get; set; }
        /// <summary>
        /// Additional details about the audit event.
        /// </summary>
        public string? AuditDetails { get; set; }
        public UserAudit() { }
        public UserAudit(int auditUserID, AuditEventType auditEvent, string? auditDetails = null)
        {
            this.AuditDate = DateTime.Now;
            this.AuditUserID = auditUserID;
            AuditEvent = auditEvent;
            AuditDetails = auditDetails;
        }
    }

    /// <summary>
    /// Represents the audit event by a specific type or action.
    /// </summary>
    public enum AuditEventType
    {
        /// <summary>
        /// When the user runs the Save command.
        /// </summary>
        WorldSaved,
        /// <summary>
        /// When the user runs a Stop command.
        /// </summary>
        StopServer,
        /// <summary>
        /// When the user runs a shutdown command.
        /// </summary>
        ShutdownServer,
        /// <summary>
        /// When the user runs a broadcast message command.
        /// </summary>
        BroadcastMessage,
        /// <summary>
        /// When the user runs a kick command.
        /// </summary>
        KickPlayer,
        /// <summary>
        /// When the user runs a ban command.
        /// </summary>
        BanPlayer,
        /// <summary>
        /// When the user runs an unban command.
        /// </summary>
        UnbanPlayer,
        /// <summary>
        /// When the user clears the audit log.
        /// </summary>
        AuditCleared,
        /// <summary>
        /// When the database is created.
        /// </summary>
        DatabaseCreated,
        /// <summary>
        /// A proxy user was created.
        /// </summary>
        UserCreated,
        /// <summary>
        /// A proxy user was edited.
        /// </summary>
        UserEdited,
        /// <summary>
        /// A proxy user was deleted.
        /// </summary>
        UserDeleted
    }
}
