using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAFE.Negocios
{
    class Informe_Visita
    {
        #region Campos
        private int _infId;
        private int _infVisita;
        private DateTime _infFecha;
        private String _infIntro;
        private String _infEvaluacion;
        private Char _infAutoevaluacion;
        private Char _infDocActualizados;
        private Char _infRegInterno;
        private Char _infDocSeremi;
        private Char _infCopiaDoc;
        private Char _infInformaRiesgos;
        private Char _infInformaMedidas;
        private Char _infProgramaOrden;
        private Char _infExtintores;
        private Char _infCapacitacionExt;
        private Char _infEppInventario;
        private Char _infEppCertificados;
        #endregion

        #region Propiedades
        public int InfId { get => _infId; set => _infId = value; }
        public int InfVisita { get => _infVisita; set => _infVisita = value; }
        public DateTime InfFecha { get => _infFecha; set => _infFecha = value; }
        public string InfIntro { get => _infIntro; set => _infIntro = value; }
        public string InfEvaluacion { get => _infEvaluacion; set => _infEvaluacion = value; }
        public char InfAutoevaluacion { get => _infAutoevaluacion; set => _infAutoevaluacion = value; }
        public char InfDocActualizados { get => _infDocActualizados; set => _infDocActualizados = value; }
        public char InfRegInterno { get => _infRegInterno; set => _infRegInterno = value; }
        public char InfDocSeremi { get => _infDocSeremi; set => _infDocSeremi = value; }
        public char InfCopiaDoc { get => _infCopiaDoc; set => _infCopiaDoc = value; }
        public char InfInformaRiesgos { get => _infInformaRiesgos; set => _infInformaRiesgos = value; }
        public char InfInformaMedidas { get => _infInformaMedidas; set => _infInformaMedidas = value; }
        public char InfProgramaOrden { get => _infProgramaOrden; set => _infProgramaOrden = value; }
        public char InfExtintores { get => _infExtintores; set => _infExtintores = value; }
        public char InfCapacitacionExt { get => _infCapacitacionExt; set => _infCapacitacionExt = value; }
        public char InfEppInventario { get => _infEppInventario; set => _infEppInventario = value; }
        public char InfEppCertificados { get => _infEppCertificados; set => _infEppCertificados = value; }
        #endregion

        #region Constructor
        public Informe_Visita(int infId, 
                              int infVisita, 
                              DateTime infFecha, 
                              string infIntro,  
                              string infEvaluacion, 
                              char infAutoevaluacion, 
                              char infDocActualizados, 
                              char infRegInterno, 
                              char infDocSeremi, 
                              char infCopiaDoc, 
                              char infInformaRiesgos, 
                              char infInformaMedidas, 
                              char infProgramaOrden, 
                              char infExtintores, 
                              char infCapacitacionExt, 
                              char infEppInventario, 
                              char infEppCertificados)
        {
            _infId = infId;
            _infVisita = infVisita;
            _infFecha = infFecha;
            _infIntro = infIntro;
            _infEvaluacion = infEvaluacion;
            _infAutoevaluacion = infAutoevaluacion;
            _infDocActualizados = infDocActualizados;
            _infRegInterno = infRegInterno;
            _infDocSeremi = infDocSeremi;
            _infCopiaDoc = infCopiaDoc;
            _infInformaRiesgos = infInformaRiesgos;
            _infInformaMedidas = infInformaMedidas;
            _infProgramaOrden = infProgramaOrden;
            _infExtintores = infExtintores;
            _infCapacitacionExt = infCapacitacionExt;
            _infEppInventario = infEppInventario;
            _infEppCertificados = infEppCertificados;
        }
        public Informe_Visita()
        {
            _infId = 0;
            _infVisita = 0;
            _infFecha = DateTime.MinValue;
            _infIntro = string.Empty;
            _infEvaluacion = string.Empty;
            _infAutoevaluacion = 'F';
            _infDocActualizados = 'F';
            _infRegInterno = 'F';
            _infDocSeremi = 'F';
            _infCopiaDoc = 'F';
            _infInformaRiesgos = 'F';
            _infInformaMedidas = 'F';
            _infProgramaOrden = 'F';
            _infExtintores = 'N';
            _infCapacitacionExt = 'N';
            _infEppInventario = 'N';
            _infEppCertificados = 'N';
        }
        #endregion

        #region Metodos
        #endregion
    }
}
