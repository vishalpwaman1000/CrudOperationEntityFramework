using CommonLayer.Model;
using RespositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class CrudOperationSL : ICrudOperationSL
    {
        private readonly ICrudOperationDL _crudOperationDL;
        public CrudOperationSL(ICrudOperationDL crudOperationDL)
        {
            _crudOperationDL = crudOperationDL;
        }

        public async Task<DeleteBookResponse> DeleteBook(int UserID)
        {
            return await _crudOperationDL.DeleteBook(UserID);
        }

        public async Task<GetBookResponse> GetBook()
        {
            return await _crudOperationDL.GetBook();
        }

        public async Task<InsertUserDetailResponse> InsertUserDetail(InsertUserDetailRequest request)
        {
            return await _crudOperationDL.InsertUserDetail(request);
        }

        public async Task<UpdateUserDetailsResponse> UpdateUserDetails(UpdateUserDetailRequest request)
        {
            return await _crudOperationDL.UpdateUserDetails(request);
        }
    }
}
