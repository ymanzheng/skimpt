using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Microsoft.Win32;
using System.Security;
using System.Security.Permissions;
using System.IO;


namespace Skimpt3.classes {
    public class skContextHandler {
   private const string MenuName = "*\\shell\\NewMenuOption";
    public const string Command = "*\\shell\\NewMenuOption\\command";

    public skContextHandler()
    {
        RegistryKey regmenu = null;
        RegistryKey regcommand = null;

        try
        {
            this.CheckSecurity();
        }
        catch(ArgumentException ex)
        {
            // RegistryPermissionAccess.AllAccess can not be used as a parameter for GetPathList.
            MessageBox.Show("An ArgumentException occured as a result of using AllAccess.  "
                          + "AllAccess cannot be used as a parameter in GetPathList because it represents more than one "
                          + "type of registry variable access : \n" + ex);
        }
        catch(SecurityException ex)
        {
            // RegistryPermissionAccess.AllAccess can not be used as a parameter for GetPathList.
            MessageBox.Show("An ArgumentException occured as a result of using AllAccess.  " + ex);
           // this.btnAddMenu.Enabled = false;
            //this.btnRemoveMenu.Enabled = false;
        }
        catch(Exception ex)
        {
            MessageBox.Show(ex.ToString());
        }
        finally
        {
            if(regmenu != null)
                regmenu.Close();
            if(regcommand != null)
                regcommand.Close();
        }
    }

    private void CheckSecurity()
    {
        //check registry permissions
        RegistryPermission regPerm;
        regPerm = new RegistryPermission(RegistryPermissionAccess.Write, "HKEY_CLASSES_ROOT\\" + MenuName);
        regPerm.AddPathList(RegistryPermissionAccess.Write, "HKEY_CLASSES_ROOT\\" + Command);
        regPerm.Demand();

    }

    public bool Add()
    {
        RegistryKey regmenu = null;
        RegistryKey regcmd = null;
        try
        {
            regmenu = Registry.ClassesRoot.CreateSubKey(MenuName);
            if(regmenu != null)
                regmenu.SetValue("", "Skimpt");
            regcmd = Registry.ClassesRoot.CreateSubKey(Command);
            if(regcmd != null)
                regcmd.SetValue("", Application.ExecutablePath + " %1");
            return true;
        }
        catch(Exception ex)
        {
            MessageBox.Show(ex.ToString());
        }
        finally
        {
            if(regmenu != null)
                regmenu.Close();
            if(regcmd != null)
                regcmd.Close();
        }               
        return false;

    }

    public static bool Remove()
    {
        RegistryKey reg = Registry.ClassesRoot.OpenSubKey(Command);
        try
        {           
            if(reg != null)
            {
                reg.Close();
                Registry.ClassesRoot.DeleteSubKey(Command);
            }
            reg = Registry.ClassesRoot.OpenSubKey(MenuName);
            if(reg != null)
            {
                reg.Close();
                Registry.ClassesRoot.DeleteSubKey(MenuName);
            }
            return true;
        }
        catch(Exception ex)
        {
            MessageBox.Show(ex.ToString());
        }
        return false;
    }


    }
}
