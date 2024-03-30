using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Drawing;

namespace Main_Real_estate.English.Master_Panal
{
    public partial class Add_Role : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();

        string Pro_R = ""; string Pro_A = ""; string Pro_E = ""; string Pro_D = "";
        string Con_R = ""; string Con_A = ""; string Con_E = ""; string Con_D = "";
        string Te_R = ""; string Te_A = ""; string Te_E = ""; string Te_D = "";
        string AsM_R = ""; string AsM_A = ""; string AsM_E = ""; string AsM_D = "";
        string Col_R = ""; string Col_E = "";
        string FS_R = ""; string FS_A = ""; string FS_E = ""; string FS_D = "";
        string Mar_R = ""; string Mar_A = ""; string Mar_E = ""; string Mar_D = "";
        string TM_R = ""; string TM_A = ""; string TM_E = ""; string TM_D = "";
        string MF_R = ""; string MF_E = "";
        string SS_R = "";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Add_Role_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                if (Pro_R_Cb.Checked == true) { Pro_R = "R"; } else { Pro_R = "0"; }
                if (Pro_A_Cb.Checked == true) { Pro_A = "A"; } else { Pro_A = "0"; }
                if (Pro_E_Cb.Checked == true) { Pro_E = "E"; } else { Pro_E = "0"; }
                if (Pro_D_Cb.Checked == true) { Pro_D = "D"; } else { Pro_D = "0"; }

                if (Con_R_Cb.Checked == true) { Con_R = "R"; } else { Con_R = "0"; }
                if (Con_A_Cb.Checked == true) { Con_A = "A"; } else { Con_A = "0"; }
                if (Con_E_Cb.Checked == true) { Con_E = "E"; } else { Con_E = "0"; }
                if (Con_D_Cb.Checked == true) { Con_D = "D"; } else { Con_D = "0"; }

                if (Te_R_Cb.Checked == true) { Te_R = "R"; } else { Te_R = "0"; }
                if (Te_A_Cb.Checked == true) { Te_A = "A"; } else { Te_A = "0"; }
                if (Te_E_Cb.Checked == true) { Te_E = "E"; } else { Te_E = "0"; }
                if (Te_D_Cb.Checked == true) { Te_D = "D"; } else { Te_D = "0"; }

                if (AsM_R_Cb.Checked == true) { AsM_R = "R"; } else { AsM_R = "0"; }
                if (AsM_A_Cb.Checked == true) { AsM_A = "A"; } else { AsM_A = "0"; }
                if (AsM_E_Cb.Checked == true) { AsM_E = "E"; } else { AsM_E = "0"; }
                if (AsM_D_Cb.Checked == true) { AsM_D = "D"; } else { AsM_D = "0"; }

                if (Col_R_Cb.Checked == true) { Col_R = "R"; } else { Col_R = "0"; }
                if (Col_E_Cb.Checked == true) { Col_E = "E"; } else { Col_E = "0"; }

                if (FS_R_Cb.Checked == true) { FS_R = "R"; } else { FS_R = "0"; }
                if (FS_A_Cb.Checked == true) { FS_A = "A"; } else { FS_A = "0"; }
                if (FS_E_Cb.Checked == true) { FS_E = "E"; } else { FS_E = "0"; }
                if (FS_D_Cb.Checked == true) { FS_D = "D"; } else { FS_D = "0"; }

                if (Mar_R_Cb.Checked == true) { Mar_R = "R"; } else { Mar_R = "0"; }
                if (Mar_A_Cb.Checked == true) { Mar_A = "A"; } else { Mar_A = "0"; }
                if (Mar_E_Cb.Checked == true) { Mar_E = "E"; } else { Mar_E = "0"; }
                if (Mar_D_Cb.Checked == true) { Mar_D = "D"; } else { Mar_D = "0"; }

                if (TM_R_Cb.Checked == true) { TM_R = "R"; } else { TM_R = "0"; }
                if (TM_A_Cb.Checked == true) { TM_A = "A"; } else { TM_A = "0"; }
                if (TM_E_Cb.Checked == true) { TM_E = "E"; } else { TM_E = "0"; }
                if (TM_D_Cb.Checked == true) { TM_D = "D"; } else { TM_D = "0"; }

                if (MF_R_Cb.Checked == true) { MF_R = "R"; } else { MF_R = "0"; }
                if (MF_E_Cb.Checked == true) { MF_E = "E"; } else { MF_E = "0"; }

                if (SS_R_Cb.Checked == true) { SS_R = "R"; } else { SS_R = "0"; }




                string Quary =
                "Insert Into roles (Role_name , properties , Contracting , Customer_Affairs , Asset_Management , Collecting , Financial_Statements , Marketing , Task_Management , Deficiency_Detection , System_Settings) " +
                "VALUES(@Role_name , @properties , @Contracting , @Customer_Affairs , @Asset_Management , @Collecting , @Financial_Statements , @Marketing , @Task_Management , @Deficiency_Detection , @System_Settings)";
                _sqlCon.Open();
                MySqlCommand Cmd = new MySqlCommand(Quary, _sqlCon);
                Cmd.Parameters.AddWithValue("@Role_name", txt_Role_Name.Text);

                Cmd.Parameters.AddWithValue("@properties", Pro_R + "," + Pro_A + "," + Pro_E + "," + Pro_D);
                Cmd.Parameters.AddWithValue("@Contracting", Con_R + "," + Con_A + "," + Con_E + "," + Con_D);
                Cmd.Parameters.AddWithValue("@Customer_Affairs", Te_R + "," + Te_A + "," + Te_E + "," + Te_D);
                Cmd.Parameters.AddWithValue("@Asset_Management", AsM_R + "," + AsM_A + "," + AsM_E + "," + AsM_D);
                Cmd.Parameters.AddWithValue("@Collecting", Col_R + ",0," + Col_E + ",0");
                Cmd.Parameters.AddWithValue("@Financial_Statements", FS_R + "," + FS_A + "," + FS_E + "," + FS_D);
                Cmd.Parameters.AddWithValue("@Marketing", Mar_R + "," + Mar_A + "," + Mar_E + "," + Mar_D);
                Cmd.Parameters.AddWithValue("@Task_Management", TM_R + "," + TM_A + "," + TM_E + "," + TM_D);
                Cmd.Parameters.AddWithValue("@Deficiency_Detection", MF_R + ",0," + MF_E + ",0");
                Cmd.Parameters.AddWithValue("@System_Settings", SS_R);

                Cmd.ExecuteNonQuery();
                _sqlCon.Close();
                lbl_Success_Add_New_Role.Text = "تمت الإضافة بنجاح ";
            }
        }

        protected void btn_Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("Roles_List.aspx");
        }

        protected void Pro_A_Cb_CheckedChanged(object sender, EventArgs e)
        {
            if (Pro_A_Cb.Checked == true || Pro_E_Cb.Checked == true || Pro_D_Cb.Checked == true) { Pro_R_Cb.Checked = true; }
            if (Con_A_Cb.Checked == true || Con_E_Cb.Checked == true || Con_D_Cb.Checked == true) { Con_R_Cb.Checked = true; }
            if (Te_A_Cb.Checked == true || Te_E_Cb.Checked == true || Te_D_Cb.Checked == true) { Te_R_Cb.Checked = true; }
            if (AsM_A_Cb.Checked == true || AsM_E_Cb.Checked == true || AsM_D_Cb.Checked == true) { AsM_R_Cb.Checked = true; }
            if (Col_E_Cb.Checked == true) { Con_R_Cb.Checked = true; }

            if (FS_A_Cb.Checked == true || FS_E_Cb.Checked == true || FS_D_Cb.Checked == true) { FS_R_Cb.Checked = true; }
            if (Mar_A_Cb.Checked == true || Mar_E_Cb.Checked == true || Mar_D_Cb.Checked == true) { Mar_R_Cb.Checked = true; }
            if (TM_A_Cb.Checked == true || TM_E_Cb.Checked == true || TM_D_Cb.Checked == true) { TM_R_Cb.Checked = true; }
            if (MF_E_Cb.Checked == true) { MF_R_Cb.Checked = true; }
        }
    }
}