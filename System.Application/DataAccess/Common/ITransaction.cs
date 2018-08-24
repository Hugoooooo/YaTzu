using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Application.DataAccess.Common
{
    interface ITransaction
    {
        #region 交易
        void BeginTransaction();
        void Commit();
        void Rollback();
        #endregion
    }
}
