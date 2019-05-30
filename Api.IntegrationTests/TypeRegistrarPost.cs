// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TypeRegistrarPost.cs" company="SS">
//   Copyright © SS. All rights reserved.
// </copyright>
// <summary>
//   Unity Registrar
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Infrastructure.Interception.Contract;
using Infrastructure.Repository.Contracts;
using Infrastructure.Testing.Repository;
using OnlineCourse.Repository;

namespace OnlineCourse.Api.IntegrationTests
{
	/// <summary>
    ///     Unity Registrar
    /// </summary>
    public class TypeRegistrarPost : ITypeRegistrarPost
    {
        /// <summary>
        ///     The register.
        /// </summary>
        /// <param name="typeRegistrarService">
        ///     The type registrar service.
        /// </param>
        public void Register(ITypeRegistrarService typeRegistrarService)
        {
            typeRegistrarService.RegisterTypeSingleton<IDbConnectionFactoryCustom<OnlineCourseContext>, DbConnectionFactoryTest<OnlineCourseContext>>();
            typeRegistrarService.RegisterTypeSingleton<IDbConnectionFactoryCustom<OnlineCourseReadContext>, DbConnectionFactoryTest<OnlineCourseReadContext>>();
        }
    }
}