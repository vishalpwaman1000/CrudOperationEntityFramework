using CommonLayer;
using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RespositoryLayer
{
    public class CrudOperationDL : ICrudOperationDL
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public CrudOperationDL(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<DeleteBookResponse> DeleteBook(int UserID)
        {
            DeleteBookResponse response = new DeleteBookResponse();
            response.IsSuccess = true;
            response.Message = "Delete Record Successfully";

            try
            {

                var Result = await _applicationDbContext.UserDetails.FindAsync(UserID);
                if (Result == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Record Not Found";
                }

                _applicationDbContext.UserDetails.Remove(Result);
                int DeleteResult = await _applicationDbContext.SaveChangesAsync();
                if (DeleteResult <= 0)
                {
                    response.IsSuccess = false;
                    response.Message = "Something went Wrong";
                }

            }catch(Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Message : " + ex.Message;
            }

            return response;
        }

        public async Task<GetBookResponse> GetBook()
        {
            GetBookResponse response = new GetBookResponse();
            response.IsSuccess = true;
            response.Message = "Fetch Data Successfully";

            try
            {
                response.data = new List<UserDetail>();
                response.data = _applicationDbContext.UserDetails.ToList();
                if (response.data.Count == 0)
                {
                    response.Message = "Data Not Found";
                }

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Message : " + ex.Message;
            }

            return response;
        }

        public async Task<InsertUserDetailResponse> InsertUserDetail(InsertUserDetailRequest request)
        {
            InsertUserDetailResponse response = new InsertUserDetailResponse();
            response.IsSuccess = true;
            response.Message = "Insert Data Successfully";

            try
            {

                UserDetail userDetail = new UserDetail()
                {
                    UserName = request.UserName,
                    Age = request.Age
                };

                await _applicationDbContext.AddAsync(userDetail);
                int Result = await _applicationDbContext.SaveChangesAsync();
                if (Result <= 0)
                {
                    response.IsSuccess = false;
                    response.Message = "Something Went Wrong";
                }

            }catch(Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Message : " + ex.Message;
            }

            return response;
        }

        public async Task<UpdateUserDetailsResponse> UpdateUserDetails(UpdateUserDetailRequest request)
        {
            UpdateUserDetailsResponse response = new UpdateUserDetailsResponse();
            response.IsSuccess = true;
            response.Message = "Update Data Successfully";

            try
            {

                var UserDetails = await _applicationDbContext.UserDetails.FindAsync(request.UserID);

                if (UserDetails == null)
                {
                    response.IsSuccess = false;
                    response.Message = "UserID not Found";
                    return response;
                }

                UserDetails.dateTime = DateTime.Now;
                UserDetails.UserName = request.UserName;
                UserDetails.Age = request.Age;

                int Result = await _applicationDbContext.SaveChangesAsync();
                if (Result <= 0)
                {
                    response.IsSuccess = false;
                    response.Message = "Something Went Wrong";
                }

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Message : " + ex.Message;
            }

            return response;
        }
    }
}
