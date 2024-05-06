using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Palworld.RESTSharp.ProxyServer;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace Palworld.RESTSharp.Client
{
    public partial class AuditPage : UserControl
    {
        PalworldRESTSharpClient palAPIClient;
        User[] proxyUsers;

        public AuditPage()
        {
            InitializeComponent();
        }

        public AuditPage(PalworldRESTSharpClient palAPIClient)
        {
            InitializeComponent();
            this.palAPIClient = palAPIClient;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnClearCriteria_Click(object sender, EventArgs e)
        {

        }

        private async void AuditPage_Load(object sender, EventArgs e)
        {
            const string dateTimeFormat = "MM/dd/yyyy hh:mm";
        }

        private async void btnWipeAudit_Click(object sender, EventArgs e)
        {
            // Prompt dialog before wiping
            DialogResult result = MessageBox.Show("Are you sure you want to wipe the audit log?", "Wipe Audit Log", MessageBoxButtons.YesNo);

            if (result.Equals(DialogResult.Yes))
            {
                await palAPIClient.ProxyServer.ClearAuditLogASync();
                MessageBox.Show("Audit log has been wiped.");
                Refresh();
            }
        }

        private async void Refresh()
        {
            UserAudit[] auditData = await palAPIClient.ProxyServer.GetUserAuditLogASync(null);

            dgAuditLog.DataSource = auditData;
            dgAuditLog.Columns["AuditUserID"].Visible = false;
            dgAuditLog.DataSource = new SortableBindingList<UserAudit>(auditData.ToList());
            dgAuditLog.Sort(dgAuditLog.Columns["AuditDate"], ListSortDirection.Descending);

        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            Refresh();
            //UserAudit[] auditData = palAPIClient.GetAuditData((int)combUsers.SelectedValue, (AuditEventType)combEventType.SelectedValue, dtFromDate.Value, dtToDate.Value);
        }
    }
}
