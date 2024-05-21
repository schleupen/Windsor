// Copyright 2004-2022 Castle Project - http://www.castleproject.org/
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

namespace Castle.Windsor.Extensions.DependencyInjection.Tests
{
	using System;
	using System.Collections.Generic;
	using Microsoft.Extensions.DependencyInjection;
	using Microsoft.Extensions.DependencyInjection.Specification;
	using Microsoft.Extensions.DependencyInjection.Specification.Fakes;
	using Xunit;

	public class WindsorScopedServiceProviderCustomWindsorContainerTests : SkippableDependencyInjectionSpecificationTests, IDisposable
	{
		private bool _disposedValue;
		private WindsorServiceProviderFactory _factory;

		protected override IServiceProvider CreateServiceProviderImpl(IServiceCollection serviceCollection)
		{
			_factory = new WindsorServiceProviderFactory(new WindsorContainer());
			var container = _factory.CreateBuilder(serviceCollection);
			return _factory.CreateServiceProvider(container);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!_disposedValue)
			{
				if (disposing)
				{
					_factory?.Dispose();
				}

				_disposedValue = true;
			}
		}

		public void Dispose()
		{
			// Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		///// <summary>
		///// To verify when a single test failed, open the corresponding test in dotnet/runtime repository,
		///// then copy the test here, change name and execute with debugging etc etc.
		///// This helps because source link support seems to be not to easy to use from the test runner
		///// and this tricks makes everything really simpler.
		///// </summary>
		//[Fact]
		//public void ClosedServicesPreferredOverOpenGenericServices_custom()
		//{
		//	// Arrange
		//	var collection = new TestServiceCollection();
		//	collection.AddTransient(typeof(IFakeOpenGenericService<PocoClass>), typeof(FakeService));
		//	collection.AddTransient(typeof(IFakeOpenGenericService<>), typeof(FakeOpenGenericService<>));
		//	collection.AddSingleton<PocoClass>();
		//	var provider = CreateServiceProvider(collection);

		//	// Act
		//	var service = provider.GetService<IFakeOpenGenericService<PocoClass>>();

		//	// Assert
		//	Assert.IsType<FakeService>(service);
		//}

#if NET6_0_OR_GREATER
#endif

	}

}
