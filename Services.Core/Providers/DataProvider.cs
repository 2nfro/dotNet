using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetaPoco;

namespace Nfro.Core.Providers {
    public abstract class DataProvider {
        protected Database db;

        protected DataProvider() {
            db = new Database("default");
        }

        protected abstract String TABLE { get; }
    }
}
