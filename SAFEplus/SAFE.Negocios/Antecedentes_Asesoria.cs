using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAFE.Negocios
{
    class Antecedentes_Asesoria
    {
        #region Campos
        private int _antId;
        private int _antIdAsesoria;
        private String _antDescripcionDoc;
        private String _antDocPath;
        //no sé como trabajar con archivos, pero lo que encontré por ahí usa el path del archivo y hace unos metodos raros para llevar y traer de la db

        #endregion

        #region Propiedades
        public int AntId { get => _antId; set => _antId = value; }
        public int AntIdAsesoria { get => _antIdAsesoria; set => _antIdAsesoria = value; }
        public string AntDescripcionDoc { get => _antDescripcionDoc; set => _antDescripcionDoc = value; }
        public string AntDocPath { get => _antDocPath; set => _antDocPath = value; }
        #endregion

        #region Constructor
        public Antecedentes_Asesoria(int antId, int antIdAsesoria, string antDescripcionDoc, string antDocPath)
        {
            _antId = antId;
            _antIdAsesoria = antIdAsesoria;
            _antDescripcionDoc = antDescripcionDoc;
            _antDocPath = antDocPath;
        }

        public Antecedentes_Asesoria()
        {
            _antId = 0;
            _antIdAsesoria = 0;
            _antDescripcionDoc = string.Empty;
            _antDocPath = string.Empty;
        }
        #endregion

        #region Metodos
        #endregion
    }
}
