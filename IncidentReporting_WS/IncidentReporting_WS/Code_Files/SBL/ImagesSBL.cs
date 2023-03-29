using System;
using SDS_Remote_Control_WS.Code_Files.CBL;
using SDS_Remote_Control_WS.Code_Files.COL;
using SDS_Remote_Control_WS.Code_Files.DAL;
using SDS_Remote_Control_WS.Code_Files.ENL;

public class ImagesSBL
{
	public ImagesSBL()
	{
        ChkCBL Chk = new ChkCBL();
        ImagesDAL ImagesDAL_Obj = new ImagesDAL();

        public Images Images_Insert(string username, string password, Images Images)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return ImagesDAL_Obj.Images_Insert( username, password, Images);
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

        public ImagesCollection Images_Select_All(string username, string password)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return ImagesDAL_Obj.Images_Select_All( username, password);
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

        public ImagesCollection Images_Select_By_BuildingID(string username, string password, int BuildingID)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return ImagesDAL_Obj.Images_Select_By_BuildingID( username, password, BuildingID);
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

        public ImagesCollection Images_Select_By_ImageDescription(string username, string password, string ImageDescription)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return ImagesDAL_Obj.Images_Select_By_ImageDescription(username, password, ImageDescription);
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
