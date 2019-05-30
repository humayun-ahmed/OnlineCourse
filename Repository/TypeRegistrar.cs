// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnityRegistrar.cs" company="SS">
//   Copyright © SS. All rights reserved.
// </copyright>
// <summary>
//   Unity Registrar
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Infrastructure.Interception.Contract;
using Infrastructure.ReadModel;
using Infrastructure.ReadModel.Conventions;
using Infrastructure.Repository;
using Infrastructure.Repository.Contracts;

namespace OnlineCourse.Repository
{
	/// <summary>
    ///     Unity Registrar
    /// </summary>
    public class TypeRegistrar : ITypeRegistrar
    {
        #region Public Methods and Operators

        /// <summary>
        /// The register.
        /// </summary>
        /// <param name="typeRegistrarService">
        /// The type registrar service.
        /// </param>
        public void Register(ITypeRegistrarService typeRegistrarService)
        {
            /*
             if (!typeof(IApplyCatalogNameConvention).IsAssignableFrom(catalogNameConventionType))
            {
                throw new Exception(
                    "'{0}' must implement interface '{1}'".FormatWith(
                        catalogNameConventionType.FullName, 
                        typeof(IApplyCatalogNameConvention).FullName));
            }
             */
            typeRegistrarService.RegisterTypeUnityOfWork<IApplyCatalogNameConvention, ClassicModelNameConvention>();

            typeRegistrarService.RegisterTypeUnityOfWork<IConnectionStringFactory<OnlineCourseContext>, ConnectionStringFactory<OnlineCourseContext>>();
            typeRegistrarService.RegisterTypeUnityOfWork<IDbConnectionFactoryCustom<OnlineCourseContext>, DbConnectionFactory<OnlineCourseContext>>();
            typeRegistrarService.RegisterTypeUnityOfWork<IDbContextFactory<OnlineCourseContext>, ReadModelContextFactory<OnlineCourseContext>>();

            typeRegistrarService.RegisterTypeUnityOfWork<IConnectionStringFactory<OnlineCourseReadContext>, ConnectionStringFactory<OnlineCourseReadContext>>();
            typeRegistrarService.RegisterTypeUnityOfWork<IDbConnectionFactoryCustom<OnlineCourseReadContext>, DbConnectionFactory<OnlineCourseReadContext>>();
            typeRegistrarService.RegisterTypeUnityOfWork<IDbContextFactory<OnlineCourseReadContext>, ReadModelContextFactory<OnlineCourseReadContext>>();

          
            typeRegistrarService.RegisterType<ITestInfo, TestInfo>();

            typeRegistrarService.RegisterTypeUnityOfWork<IRepositoryReadOnlineCourse, RepositoryReadOnlineCourse>();
            typeRegistrarService.RegisterTypeUnityOfWork<IRepositoryOnlineCourse, RepositoryOnlineCourse>();
        }

        #endregion
    }
}