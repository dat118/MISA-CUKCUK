﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MISA.cukcuk.API.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("MISA.cukcuk.API.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to misa-001.
        /// </summary>
        public static string error_code {
            get {
                return ResourceManager.GetString("error-code", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Mã khách hàng bị trùng!.
        /// </summary>
        public static string error_duplicateCode {
            get {
                return ResourceManager.GetString("error-duplicateCode", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Mã khách hàng không được để trống!.
        /// </summary>
        public static string error_emptyCode {
            get {
                return ResourceManager.GetString("error-emptyCode", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Email không hợp lệ!.
        /// </summary>
        public static string error_invalidEmail {
            get {
                return ResourceManager.GetString("error-invalidEmail", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Có lỗi xảy ra, vui lòng liên hệ MISA!.
        /// </summary>
        public static string error_userMsg {
            get {
                return ResourceManager.GetString("error-userMsg", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to https://openapi.misa.com.vn/errorcode/misa-001.
        /// </summary>
        public static string more_information {
            get {
                return ResourceManager.GetString("more-information", resourceCulture);
            }
        }
    }
}
