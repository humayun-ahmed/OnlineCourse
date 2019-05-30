// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnityRegistrar.cs" company="SS">
//   Copyright © SS. All rights reserved.
// </copyright>
// <summary>
//   Unity Registrar
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Infrastructure.Interception.Contract;
using OnlineCourse.ApplicationService.Contracts;

namespace OnlineCourse.ApplicationService
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
            typeRegistrarService.RegisterTypeUnityOfWork<ICourseServiceWrite, CourseServiceWrite>();
            typeRegistrarService.RegisterTypeUnityOfWork<ICourseServiceRead, CourseServiceRead>();
        }

        #endregion
    }
}