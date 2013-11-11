using System;
using System.Data.Entity;

namespace NGnono.Framework.Data.EF
{
    /// <summary>
    /// 
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// 
        /// </summary>
        void Commit();

        /// <summary>
        /// 释放
        /// </summary>
        void Close();
    }

    /// <summary>
    /// 
    /// </summary>
    public abstract class EFUnitOfWork : IUnitOfWork
    {
        private bool _isDisposed;

        protected EFUnitOfWork(DbContext dbContext)
        {
            DbContext = dbContext;
            _isDisposed = false;
        }

        //~EFUnitOfWork()
        //{
        //    Dispose(false);
        //}

        /// <summary>
        /// 
        /// </summary>
        public DbContext DbContext { get; set; }

        public void Close()
        {
            Dispose();
        }

        // public DbTransaction Transaction { get; set; }

        public void Commit()
        {
            if (DbContext != null)
            {
                DbContext.SaveChanges();
                //if (Transaction != null)
                //{
                //    if (Transaction.Connection != null)
                //    {
                //        Transaction.Commit();
                //    }
                //}
            }
        }

        public void Dispose()
        {
            Dispose(true);
            //.NET Framework 类库
            // GC..::.SuppressFinalize 方法 
            //请求系统不要调用指定对象的终结器。
            //GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool isDisposing)
        {
            if (!_isDisposed)
            {
                if (isDisposing)
                {
                    // Release managed resources
                }

                // Release unmanaged resources
                if (DbContext != null)
                {
                    DbContext.Dispose();
                    //Context = null;
                }

                _isDisposed = true;
            }
        }
    }
}