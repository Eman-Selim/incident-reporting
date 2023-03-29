using System;
using SDS_Remote_Control_WS.Code_Files.CBL;
using SDS_Remote_Control_WS.Code_Files.COL;
using SDS_Remote_Control_WS.Code_Files.DAL;
using SDS_Remote_Control_WS.Code_Files.ENL;

public class UsersSBL
{
	public UsersSBL()
	{
        ChkCBL Chk = new ChkCBL();
        UsersDAL UsersDAL_Obj = new UsersDAL();

        public bool Users_Delete(string username, string password, int user_id)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return UsersDAL_Obj.Users_Delete( username, password, user_id);
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

        public Users Users_Insert(string username, string password, Users Users)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return UsersDAL_Obj.Users_Insert( username, password, Users);
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

        public UsersCollection Users_Select_All(string username, string password)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return UsersDAL_Obj.Users_Select_All( username, password);
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

        public Users Users_SelectByUserId(string username, string password, int UserId)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return UsersDAL_Obj.Users_SelectByUserId( username, password, UserId);
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

        public UsersCollection Users_Select_Super_Admin(string username, string password)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return UsersDAL_Obj.Users_Select_Super_Admin( username, password);
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
