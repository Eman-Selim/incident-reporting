﻿using System;
using SDS_Remote_Control_WS.Code_Files.CBL;
using SDS_Remote_Control_WS.Code_Files.COL;
using SDS_Remote_Control_WS.Code_Files.DAL;
using SDS_Remote_Control_WS.Code_Files.ENL;

public class Users_AdminSBL
{
	public Users_AdminSBL()
	{
        ChkCBL Chk = new ChkCBL();
        Users_AdminDAL Users_AdminDAL_Obj = new Users_AdminDAL();

        public bool Users_Admin_Delete(string username, string password, int user_id, int Admin_id)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return Users_AdminDAL_Obj.Users_Admin_Delete( username, password, user_id, Admin_id);
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Users_Admin Users_Admin_Insert(string username, string password, Users_Admin Users_Admin)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return Users_AdminDAL_Obj.Users_Admin_Insert( username, password, Users_Admin);
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Users_AdminCollection Users_Admin_Select_All(string username, string password)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return Users_AdminDAL_Obj.Users_Admin_Select_All( username, password);
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Users_Admin Users_Admin_SelectByAdminId(string username, string password, int Admin_ID)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return Users_AdminDAL_Obj.Users_Admin_SelectByAdminId( username, password, Admin_ID);
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Users_Admin Users_Admin_SelectByUserID(string username, string password, int User_ID)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return Users_AdminDAL_Obj.Users_Admin_SelectByUserID( username, password, User_ID);
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }


    }
}
