﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.42
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.CompactFramework.Design.Data, Version 2.0.50727.42.
// 
namespace bitirmePDA_WM5.kullaniciWebServisi {
    using System.Diagnostics;
    using System.Web.Services;
    using System.ComponentModel;
    using System.Web.Services.Protocols;
    using System;
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="kullaniciWSSoap", Namespace="http://localhost/kullaniciWS/")]
    public partial class kullaniciWS : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        /// <remarks/>
        public kullaniciWS() {
            this.Url = "http://160.75.96.32/1/webServices/kullaniciWS.asmx";
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://localhost/kullaniciWS/giris", RequestNamespace="http://localhost/kullaniciWS/", ResponseNamespace="http://localhost/kullaniciWS/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool giris(string isim, string sifre) {
            object[] results = this.Invoke("giris", new object[] {
                        isim,
                        sifre});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult Begingiris(string isim, string sifre, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("giris", new object[] {
                        isim,
                        sifre}, callback, asyncState);
        }
        
        /// <remarks/>
        public bool Endgiris(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://localhost/kullaniciWS/idGetir", RequestNamespace="http://localhost/kullaniciWS/", ResponseNamespace="http://localhost/kullaniciWS/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public uint idGetir(string isim) {
            object[] results = this.Invoke("idGetir", new object[] {
                        isim});
            return ((uint)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginidGetir(string isim, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("idGetir", new object[] {
                        isim}, callback, asyncState);
        }
        
        /// <remarks/>
        public uint EndidGetir(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((uint)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://localhost/kullaniciWS/tipGetir", RequestNamespace="http://localhost/kullaniciWS/", ResponseNamespace="http://localhost/kullaniciWS/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string tipGetir(string isim) {
            object[] results = this.Invoke("tipGetir", new object[] {
                        isim});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BegintipGetir(string isim, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("tipGetir", new object[] {
                        isim}, callback, asyncState);
        }
        
        /// <remarks/>
        public string EndtipGetir(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string)(results[0]));
        }
    }
}
