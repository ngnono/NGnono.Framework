using System;
using System.Data.Entity;

namespace NGnono.Framework.Data.EF
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();

        DbContext Context { get; set; }
        // DbTransaction Transaction { get; set; }
    }

    public class UnitOfWork : IUnitOfWork
    {
        private bool _isDisposed;

        public DbContext Context { get; set; }
        // public DbTransaction Transaction { get; set; }

        ~UnitOfWork()
        {
            Dispose(false);
        }

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
                    if (Context != null)
                    {
                        Context.Dispose();
                        Context = null;
                    }
                }

                // Release unmanaged resources
                _isDisposed = true;
            }
        }
    }
}