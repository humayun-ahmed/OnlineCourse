// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnityRegistrar.cs" company="SS">
//   Copyright © SS. All rights reserved.
// </copyright>
// <summary>
//   Unity Registrar
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Infrastructure.ApiDocumentation.Contracts;
using Infrastructure.Interception.Contract;
using OnlineCourse.Api.ApiDocumentation;

namespace OnlineCourse.Api
{
	/// <summary>
    ///     Unity Registrar
    /// </summary>
    public class TypeRegistrar : ITypeRegistrar
    {
        #region Public Methods and Operators

        /// <summary>
        ///     The register.
        /// </summary>
        /// <param name="typeRegistrarService">
        ///     The type registrar service.
        /// </param>
        public void Register(ITypeRegistrarService typeRegistrarService)
        {
            typeRegistrarService.RegisterTypeSingleton<IApiHeaderParameterMap, ApiHeaderParameterMappings>();
            typeRegistrarService.RegisterTypeSingleton<IApiDocConfig, ApiDocConfig>();
        }

        #endregion
    }
}