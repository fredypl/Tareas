using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;

namespace Tareas
{
   public class _13090300
    {
        string id;
        string titulo;
        string descripcion;
        string perasig;
        string prioridad;
        DateTime fecha;
        string dependencia;
        string status;
        bool deleted;

        [JsonProperty(propertyName: "Id")]
        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        [JsonProperty(propertyName: "Titulo")]
        public string Titulo
        {
            get { return titulo; }
            set { titulo = value; }
        }
        [JsonProperty(propertyName: "Descripcion")]
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        [JsonProperty(propertyName: "PerAsig")]
        public string PerAsig
        {
            get { return perasig; }
            set { perasig = value; }
        }
        [JsonProperty(propertyName: "Prioridad")]
        public string Prioridad
        {
            get { return prioridad; }
            set { prioridad = value; }
        }
        [JsonProperty(propertyName: "Fecha")]
        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }
        [JsonProperty(propertyName: "Dependencia")]
        public string Dependencia
        {
            get { return dependencia; }
            set { dependencia = value; }
        }
        [JsonProperty(propertyName: "Status")]
        public string Status
        {
            get { return status; }
            set { status = value; }
        }
         [Version]
        public string Version { get; set; }

        [JsonProperty(propertyName: "deleted")]
        public bool Deleted
        {
            get { return deleted; }
            set { deleted = value; }
        }
    }
}


