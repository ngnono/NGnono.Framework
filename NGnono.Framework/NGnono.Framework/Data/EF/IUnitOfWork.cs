using System;
using System.Data.Entity;

namespace NGnono.Framework.Data.EF
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();

        /// <summary>
        /// 释放
        /// </summary>
        void Close();
    }

    public abstract class EfUnitOfWork : IUnitOfWork
    {
        private bool _isDisposed;

        protected EfUnitOfWork(DbContext dbContext)
        {
            Context = dbContext;
            _isDisposed = false;
        }

        ~EfUnitOfWork()
        {
            Dispose(false);
        }

        public DbContext Context { get; set; }

        public void Close()
        {
            Dispose();
        }

        // public DbTransaction Transaction { get; set; }

        public void Commit()
        {
            if (Context != null)
            {
                Context.SaveChanges();
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
            GC.SuppressFinalize(this);
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
                if (Context != null)
                {
                    Context.Dispose();
                    Context = null;
                }

                _isDisposed = true;
            }
        }
    }
}