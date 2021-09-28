using Autofac;
using DataImporter.Transfer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataImporter.Worker.Model
{
    public class ImportInsertModel
    {
        private IImportService _importService;
        private ILifetimeScope _scope;
        public ImportInsertModel()
        {
            
        }
        public void Resolve(ILifetimeScope scope, IImportService importService)
        {
            _scope = scope;
            _importService = _scope.Resolve<IImportService>();
        }

        public ImportInsertModel(IImportService importService)
        {
            _importService = importService;
        }

        public void DeleteFile()
        {

        }
    }
}
