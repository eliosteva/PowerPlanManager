using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPlanManager
{
	class ControlContainer : IContainer
	{

		ComponentCollection _components;

		public ControlContainer()
		{
			_components = new ComponentCollection(new IComponent[] { });
		}

		public void Add(IComponent component)
		{ }

		public void Add(IComponent component, string Name)
		{ }

		public void Remove(IComponent component)
		{ }

		public ComponentCollection Components
		{
			get { return _components; }
		}

		public void Dispose()
		{
			_components = null;
		}
	}
}


