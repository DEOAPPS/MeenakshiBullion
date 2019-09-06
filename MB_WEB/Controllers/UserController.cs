using MB_WEB.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace MB_WEB.Controllers
{
    public class UserController : ApiController
    {
        sri123_mbdbEntities1 db = new sri123_mbdbEntities1();
        [HttpPost]
        [ActionName("Login")]

        public HttpResponseMessage Login(MUserLoginPara usrObj)
        {
            HttpResponseMessage response;
            MUser objMessage = new MUser();
            try
            {
                if (!string.IsNullOrEmpty(usrObj.MobileNo) && !string.IsNullOrEmpty(usrObj.MobileNo))
                {
                    user_tbl userLog = db.user_tbl.Where(s => s.USER_MOBILENO == usrObj.MobileNo && s.USER_PASSWORD == usrObj.Password && s.USER_TYPE == "2").Select(s => s).FirstOrDefault();
                    if (userLog != null)
                    {
                        if (userLog.IS_ACTIVE == "Y")
                        {
                            objMessage.Email = userLog.USER_MAIL_ID;
                            //objMessage.ucode = userLog.ucode;
                            objMessage.Name = userLog.NAME;
                            //objMessage.lname = userLog.lname;

                            objMessage.MobileNumber = userLog.USER_MOBILENO;
                            objMessage.User_ID = userLog.USER_ID;

                            objMessage.Msg.ErrorCode = 200;
                            objMessage.Msg.isError = false;
                            objMessage.Msg.isSuccess = true;
                            objMessage.Msg.Message = "Login successfully";
                            return response = Request.CreateResponse(HttpStatusCode.OK, objMessage);


                        }
                        else if (userLog.IS_ACTIVE == "N")
                        {
                            objMessage.Msg.ErrorCode = 401;
                            objMessage.Msg.isError = true;
                            objMessage.Msg.isSuccess = false;
                            objMessage.Msg.Message = "User Is not Valid";
                            return response = Request.CreateResponse(HttpStatusCode.Unauthorized, objMessage);
                        }
                        else
                        {
                            objMessage.Msg.ErrorCode = 401;
                            objMessage.Msg.isError = true;
                            objMessage.Msg.isSuccess = false;
                            objMessage.Msg.Message = "User Is not Valid";
                            return response = Request.CreateResponse(HttpStatusCode.Unauthorized, objMessage);
                        }
                    }
                    else
                    {
                        objMessage.Msg.ErrorCode = 401;
                        objMessage.Msg.isError = true;
                        objMessage.Msg.isSuccess = false;
                        objMessage.Msg.Message = "Invalid Credentials";
                        return response = Request.CreateResponse(HttpStatusCode.Unauthorized, objMessage);
                    }
                }
                else
                {
                    objMessage.Msg.ErrorCode = 400;
                    objMessage.Msg.isError = true;
                    objMessage.Msg.Message = "Invalid Input Parameters";
                    return response = Request.CreateResponse(HttpStatusCode.BadRequest, objMessage);
                }
            }
            catch (Exception ex)
            {
                objMessage.Msg.ErrorCode = 500;
                objMessage.Msg.isError = true;
                objMessage.Msg.isSuccess = false;
                objMessage.Msg.Message = ex.Message;
                return response = Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost]
        [ActionName("CustomerReg")]
        public HttpResponseMessage CustomerRegistration(MCustomeDt usrObj)
        {
            HttpResponseMessage response;
            Messages oMsg = new Messages();

            customer_tbl CustTb = new customer_tbl();
            try
            {
                if (!string.IsNullOrEmpty(usrObj.COMPANY_NAME) && !string.IsNullOrEmpty(usrObj.EMAIL_ID))
                {
                    using (sri123_mbdbEntities1 dbContext = new sri123_mbdbEntities1())
                    {
                        using (var dbContextTransaction = dbContext.Database.BeginTransaction())
                        {
                            try
                            {

                                CustTb.ALTERNATE_NO = usrObj.ALTERNATE_NO;
                                CustTb.CENTRAL_TAX_NO = usrObj.CENTRAL_TAX_NO;
                                CustTb.COMPANY_NAME = usrObj.COMPANY_NAME;
                                //CustTb.CREATED_DATE=
                                CustTb.EMAIL_ID = usrObj.EMAIL_ID;
                                CustTb.FATHERS_NAME = usrObj.FATHERS_NAME;
                                CustTb.GST_NO = usrObj.GST_NO;
                                CustTb.MOBILE_NO = usrObj.MOBILE_NO;
                                CustTb.MOTHERS_NAME = usrObj.MOTHERS_NAME;
                                CustTb.NAME = usrObj.NAME;
                                CustTb.PADDR_ADDRESS = usrObj.PADDR_ADDRESS;
                                CustTb.PADDR_COUNTRY = usrObj.PADDR_COUNTRY;
                                CustTb.PADDR_DISTRICT = usrObj.PADDR_DISTRICT;
                                CustTb.PADDR_PIN_CODE = usrObj.PADDR_PIN_CODE;
                                CustTb.PADDR_STATE = usrObj.PADDR_STATE;
                                CustTb.REMARKS = usrObj.REMARKS;
                                CustTb.SADDR_ADDRESS = usrObj.SADDR_ADDRESS;
                                CustTb.SADDR_COUNTRY = usrObj.SADDR_COUNTRY;
                                CustTb.SADDR_DISTRICT = usrObj.SADDR_DISTRICT;
                                CustTb.SADDR_PIN_CODE = usrObj.SADDR_PIN_CODE;
                                CustTb.SADDR_STATE = usrObj.SADDR_STATE;
                                CustTb.SALES_TAX_NO = usrObj.SALES_TAX_NO;
                                //CustTb.SENDER_ID_NO = "100";

                                //CustTb.USER_ID = ObJuser.USER_ID;

                                //CustTb.
                                if (usrObj.PHOTO != null)
                                {
                                    byte[] imageBytes = Convert.FromBase64String(usrObj.PHOTO);

                                    //Save the Byte Array as Image File.
                                    string filePath = HttpContext.Current.Server.MapPath("~/Content/CustPic/" + usrObj.MOBILE_NO + "Image.jpg");
                                    File.WriteAllBytes(filePath, imageBytes);

                                    CustTb.PHOTO = "/Content/CustPic/" + usrObj.MOBILE_NO + "Image.jpg";
                                }
                                CustTb.CREATED_DATE = DateTime.Now;
                                CustTb.UPDATED_DATE = DateTime.Now;
                                dbContext.customer_tbl.Add(CustTb);
                                dbContext.SaveChanges();


                                user_tbl ObJuser = new user_tbl();

                                ObJuser.NAME = usrObj.NAME;
                                ObJuser.USER_MAIL_ID = usrObj.EMAIL_ID;
                                ObJuser.USER_MOBILENO = usrObj.MOBILE_NO;
                                ObJuser.USER_PASSWORD = "Mbuser@123";
                                ObJuser.USER_TYPE = "3";
                            
                                ObJuser.IS_ACTIVE = "Y";
                                ObJuser.CREATED_DATE = DateTime.Now;
                                ObJuser.UPDATED_DATE = DateTime.Now;
                                ObJuser.CUSTOMER_ID = CustTb.CUSTOMER_ID;
                                dbContext.user_tbl.Add(ObJuser);
                                dbContext.SaveChanges();

                                dbContextTransaction.Commit();
                                SendSMS clsSendSMS = new SendSMS();
                                int result = clsSendSMS.sendSMS(CustTb.MOBILE_NO, "Dear "+CustTb.NAME+",Your Registration is successfully completed. Please check your account details using this website http://meenakshibullion.com/ .Credentials are username: "+CustTb.MOBILE_NO+" and Password: "+ ObJuser.USER_PASSWORD + ".");
                                oMsg.isSuccess = true;
                                oMsg.ErrorCode = 200;

                                oMsg.Message = "Customer Registred Successfully";

                                SendSMS ObjSms = new SendSMS();
                                //String Messahe=
                               // int result = ObjSms.sendSMS(CustTb.MOBILE_NO,)
                                return response = Request.CreateResponse(HttpStatusCode.Accepted, oMsg);

                            }
                            catch (Exception ex)
                            {
                                oMsg.isError = true;
                                oMsg.ErrorCode = 400;
                                oMsg.Message = ex.Message;
                                dbContextTransaction.Rollback();
                                return response = Request.CreateResponse(HttpStatusCode.Unauthorized, oMsg);
                            }

                        }
                    }
                }


                else
                {
                    oMsg.ErrorCode = 401;
                    oMsg.isError = true;
                    oMsg.isSuccess = false;
                    oMsg.Message = "Invalid InputParamaters";
                    return response = Request.CreateResponse(HttpStatusCode.Unauthorized, oMsg);
                }
                //}
                //else
                //{
                //    objMessage.Msg.ErrorCode = 400;
                //    objMessage.Msg.isError = true;
                //    objMessage.Msg.Message = "Invalid Input Parameters";
                //    return response = Request.CreateResponse(HttpStatusCode.BadRequest, objMessage);
                //}
            }
            catch (Exception ex)
            {
                oMsg.ErrorCode = 500;
                oMsg.isError = true;
                oMsg.isSuccess = false;
                oMsg.Message = ex.Message;
                return response = Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }


        [HttpGet]
        [ActionName("CustomerList")]

        public HttpResponseMessage CustomerList(int UserID)
        {
            HttpResponseMessage response;
            MCustomerList list = new MCustomerList();
            try
            {
                if (UserID != 0)
                {
                    List<customer_tbl> userLog = db.customer_tbl.Where(s => s.USER_ID == UserID).Select(s => s).ToList();
                    if (userLog.Count > 0)
                    {
                        foreach (var Item in userLog)
                        {
                            list.CustomerList.Add(new MCustomerView()
                            {
                                CustomerID= Item.CUSTOMER_ID,
                                CompanyName = Item.COMPANY_NAME,
                                CustomerName = Item.NAME,
                                MobileNumber = Item.MOBILE_NO

                            });


                        }

                        list.Msg.ErrorCode = 200;
                        list.Msg.isError = false;
                        list.Msg.isSuccess = true;
                        list.Msg.Message = "Customer details successfuly generated";

                        return response = Request.CreateResponse(HttpStatusCode.Accepted, list);
                    }
                    else
                    {
                        list.Msg.ErrorCode = 401;
                        list.Msg.isError = true;
                        list.Msg.isSuccess = false;
                        list.Msg.Message = "Invalid Credentials";
                        return response = Request.CreateResponse(HttpStatusCode.Unauthorized, list.Msg);
                    }
                }
                else
                {
                    list.Msg.ErrorCode = 400;
                    list.Msg.isError = true;
                    list.Msg.Message = " There is no asigned customers";
                    return response = Request.CreateResponse(HttpStatusCode.NotAcceptable, list.Msg);
                }
            }
            catch (Exception ex)
            {
                list.Msg.ErrorCode = 500;
                list.Msg.isError = true;
                list.Msg.isSuccess = false;
                list.Msg.Message = ex.Message;
                return response = Request.CreateResponse(HttpStatusCode.InternalServerError, list.Msg);
            }
        }


        [HttpGet]
        [ActionName("CustomerDetail")]

        public HttpResponseMessage CustomerDetails(int CustomerID)
        {
            HttpResponseMessage response;
            MCustomerDetail list = new MCustomerDetail();
            try
            {
                if (CustomerID != 0)
                {
                    customer_tbl userLog = db.customer_tbl.Where(s => s.CUSTOMER_ID == CustomerID).Select(s => s).FirstOrDefault();
                    if (userLog != null)
                    {

                        list.CENTRAL_TAX_NO = userLog.CENTRAL_TAX_NO;
                        list.ALTERNATE_NO = userLog.ALTERNATE_NO;
                        list.COMPANY_NAME = userLog.COMPANY_NAME;
                        list.CREATED_DATE = userLog.CREATED_DATE;
                        list.CUSTOMER_ID = userLog.CUSTOMER_ID;
                        list.EMAIL_ID = userLog.EMAIL_ID;
                        list.FATHERS_NAME = userLog.FATHERS_NAME;
                        list.GST_NO = userLog.GST_NO;
                        list.MOBILE_NO = userLog.MOBILE_NO;
                        list.MOTHERS_NAME = userLog.MOTHERS_NAME;
                        list.NAME = userLog.NAME;
                        list.PADDR_ADDRESS = userLog.PADDR_ADDRESS;
                        list.PADDR_COUNTRY = userLog.PADDR_COUNTRY;
                        list.PADDR_DISTRICT = userLog.PADDR_DISTRICT;
                        list.PADDR_PIN_CODE = userLog.PADDR_PIN_CODE;
                        list.PADDR_STATE = userLog.PADDR_STATE;
                        list.PHOTO = userLog.PHOTO == string.Empty ? string.Empty : "http://meenakshibullion.com" + userLog.PHOTO;
                        list.REMARKS = userLog.REMARKS;
                        list.SADDR_ADDRESS = userLog.SADDR_ADDRESS;
                        list.SADDR_COUNTRY = userLog.SADDR_COUNTRY;
                        list.SADDR_DISTRICT = userLog.SADDR_DISTRICT;
                        list.SADDR_PIN_CODE = userLog.SADDR_PIN_CODE;
                        list.SADDR_STATE = userLog.SADDR_STATE;
                        list.SALES_TAX_NO = userLog.SALES_TAX_NO;
                        list.UPDATED_DATE = userLog.UPDATED_DATE;
                        list.USER_ID = userLog.USER_ID;
                        // list.


                        list.Msg.ErrorCode = 200;
                        list.Msg.isError = false;
                        list.Msg.isSuccess = true;
                        list.Msg.Message = "Customer details successfuly generated";

                        return response = Request.CreateResponse(HttpStatusCode.Accepted, list);
                    }
                    else
                    {
                        list.Msg.ErrorCode = 401;
                        list.Msg.isError = true;
                        list.Msg.isSuccess = false;
                        list.Msg.Message = "Invalid CusterID";
                        return response = Request.CreateResponse(HttpStatusCode.Unauthorized, list.Msg);
                    }
                }
                else
                {
                    list.Msg.ErrorCode = 400;
                    list.Msg.isError = true;
                    list.Msg.Message = " There is no asigned customers";
                    return response = Request.CreateResponse(HttpStatusCode.NotAcceptable, list.Msg);
                }
            }
            catch (Exception ex)
            {
                list.Msg.ErrorCode = 500;
                list.Msg.isError = true;
                list.Msg.isSuccess = false;
                list.Msg.Message = ex.Message;
                return response = Request.CreateResponse(HttpStatusCode.InternalServerError, list.Msg);
            }
        }


        [HttpPost]
        [ActionName("CustomerCollection")]
        public HttpResponseMessage CustomerCollection(MCollections usrObj)
        {
            HttpResponseMessage response;
            Messages oMsg = new Messages();
            try
            {
                if (usrObj.CUSTOMER_ID > 0 && usrObj.USER_ID > 0)

                {
                    using (sri123_mbdbEntities1 dbContext = new sri123_mbdbEntities1())
                    {
                        using (var dbContextTransaction = dbContext.Database.BeginTransaction())
                        {
                            try
                            {
                                user_collections_tbl ObjColl = new user_collections_tbl();

                                ObjColl.AMOUNT = usrObj.AMOUNT;
                                ObjColl.CREATED_DATE = DateTime.Now;
                                ObjColl.CUSTOMER_ID = usrObj.CUSTOMER_ID;
                                ObjColl.USER_ID = usrObj.USER_ID;

                                dbContext.user_collections_tbl.Add(ObjColl);
                                dbContext.SaveChanges();

                                dbContextTransaction.Commit();

                                var Customerdt = db.customer_tbl.Where(s => s.CUSTOMER_ID == usrObj.CUSTOMER_ID).Select(s => s).FirstOrDefault();
                                var AgentName = db.user_tbl.Where(s => s.USER_ID == usrObj.USER_ID).Select(s => s.NAME).FirstOrDefault();
                                SendSMS clsSendSMS = new SendSMS();
                                int result = clsSendSMS.sendSMS(Customerdt.MOBILE_NO, "Dear "+ Customerdt.NAME+ ",Your Amount Received through our Agent "+ AgentName + " is "+ usrObj.AMOUNT+ ".Date of "+ ObjColl.CREATED_DATE+"");
                                int result2 = clsSendSMS.sendSMS("8465899994", "Dear " + Customerdt.NAME + ",Your Amount Received through our Agent " + AgentName + " is " + usrObj.AMOUNT + ".Date of " + ObjColl.CREATED_DATE + "");
                                oMsg.isSuccess = true;
                                oMsg.ErrorCode = 200;

                                oMsg.Message = "Amount registred successfully";
                                return response = Request.CreateResponse(HttpStatusCode.Accepted, oMsg);

                            }
                            catch (Exception ex)
                            {
                                oMsg.isError = true;
                                oMsg.ErrorCode = 400;
                                oMsg.Message = ex.Message;
                                dbContextTransaction.Rollback();
                                return response = Request.CreateResponse(HttpStatusCode.Unauthorized, oMsg);
                            }

                        }
                    }
                }


                else
                {
                    oMsg.ErrorCode = 401;
                    oMsg.isError = true;
                    oMsg.isSuccess = false;
                    oMsg.Message = "Invalid InputParamaters";
                    return response = Request.CreateResponse(HttpStatusCode.Unauthorized, oMsg);
                }
                //}
                //else
                //{
                //    objMessage.Msg.ErrorCode = 400;
                //    objMessage.Msg.isError = true;
                //    objMessage.Msg.Message = "Invalid Input Parameters";
                //    return response = Request.CreateResponse(HttpStatusCode.BadRequest, objMessage);
                //}
            }
            catch (Exception ex)
            {
                oMsg.ErrorCode = 500;
                oMsg.isError = true;
                oMsg.isSuccess = false;
                oMsg.Message = ex.Message;
                return response = Request.CreateResponse(HttpStatusCode.InternalServerError, oMsg);
            }
        }


        [HttpGet]
        [ActionName("GetCustomerCollection")]
        public HttpResponseMessage GetCustomerCollection(int CustomerID)
        {
            HttpResponseMessage response;
            MCustomerCollectinsList list = new MCustomerCollectinsList();
            try
            {
                if (CustomerID > 0 )

                {
                  List<user_collections_tbl> userLog = db.user_collections_tbl.Where(s => s.CUSTOMER_ID == CustomerID).Select(s => s).ToList();
                    if (userLog.Count>0)
                    {

                        double SumAmount = userLog.Sum(s => s.AMOUNT);

                        Nullable< decimal > TotAmount = db.customer_tbl.Where(s => s.CUSTOMER_ID == CustomerID).Select(s => s.AMOUNT).FirstOrDefault();
                        if (TotAmount != null && SumAmount!=0)
                        {
                            list.BalanceAmount = (TotAmount.Value - Convert.ToDecimal(SumAmount));
                        }
                        foreach (var Items in userLog)
                        {
                            list.CollectionDetails.Add(new MCustomerCollectins()
                            {
                                Amount = Items.AMOUNT,
                                CollectionDate = Items.CREATED_DATE.ToString("dd-MM-yyyy"),
                                CustomerID = Items.CUSTOMER_ID,
                                CustomerName= db.customer_tbl.Where(s=>s.CUSTOMER_ID== Items.CUSTOMER_ID).Select(s=>s.NAME).FirstOrDefault(),

                            });


                        }
                       


                        list.Msg.ErrorCode = 200;
                        list.Msg.isError = false;
                        list.Msg.isSuccess = true;
                        list.Msg.Message = "Customer collections details successfuly generated";

                        return response = Request.CreateResponse(HttpStatusCode.Accepted, list);
                    }
                    else
                    {
                        list.Msg.ErrorCode = 401;
                        list.Msg.isError = true;
                        list.Msg.isSuccess = false;
                        list.Msg.Message = "There is no collection  for this customer";
                        return response = Request.CreateResponse(HttpStatusCode.Unauthorized, list.Msg);
                    }
                }


                else
                {
                    list.Msg.ErrorCode = 401;
                    list.Msg.isError = true;
                    list.Msg.isSuccess = false;
                    list.Msg.Message = "Invalid InputParamaters";
                  //  oMsg.Message = "";
                    return response = Request.CreateResponse(HttpStatusCode.Unauthorized, list.Msg);
                }
                //}
                //else
                //{
                //    objMessage.Msg.ErrorCode = 400;
                //    objMessage.Msg.isError = true;
                //    objMessage.Msg.Message = "Invalid Input Parameters";
                //    return response = Request.CreateResponse(HttpStatusCode.BadRequest, objMessage);
                //}
            }
            catch (Exception ex)
            {
                list.Msg.ErrorCode = 401;
                list.Msg.isError = true;
                list.Msg.isSuccess = false;
                list.Msg.Message = ex.Message;
                return response = Request.CreateResponse(HttpStatusCode.InternalServerError, list.Msg);
            }
        }
    }
}
