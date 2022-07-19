﻿using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public interface ICrudOperationSL
    {
        public Task<InsertUserDetailResponse> InsertUserDetail(InsertUserDetailRequest request);
        public Task<GetBookResponse> GetBook();
        public Task<UpdateUserDetailsResponse> UpdateUserDetails(UpdateUserDetailRequest request);
        public Task<DeleteBookResponse> DeleteBook(int UserID);
    }
}
