using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeduShop.Data.Infrastructure
{
    public class Disposable : IDisposable
    {
        // Nó là 1 lớp có sẵn của C#, những cái nào kế thừa từ nó có thể tự động hủy cài đặt các phương thức
        // Nó dùng để tắt đối tượng khi mà không dùng đến
        private bool isDisposed;

        ~Disposable()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);  // Thu hoạch bộ nhớ
        }
        private void Dispose(bool disposing)
        {
            if (!isDisposed && disposing)
            {
                DisposeCore();
            }

            isDisposed = true;
        }

        // Ovveride this to dispose custom objects
        protected virtual void DisposeCore()
        {
        }
    }
}
