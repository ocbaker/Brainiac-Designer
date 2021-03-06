////////////////////////////////////////////////////////////////////////////////////////////////////
// Copyright (c) 2009, Daniel Kollmann
// All rights reserved.
//
// Redistribution and use in source and binary forms, with or without modification, are permitted
// provided that the following conditions are met:
//
// - Redistributions of source code must retain the above copyright notice, this list of conditions
//   and the following disclaimer.
//
// - Redistributions in binary form must reproduce the above copyright notice, this list of
//   conditions and the following disclaimer in the documentation and/or other materials provided
//   with the distribution.
//
// - Neither the name of Daniel Kollmann nor the names of its contributors may be used to endorse
//   or promote products derived from this software without specific prior written permission.
//
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR
// IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR
// CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
// DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE,
// DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY,
// WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY
// WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using Brainiac.Design;
using Vampire.Properties;

namespace Vampire
{
	/// <summary>
	/// The plugin for Project Hoshimi which is loaded when you start the editor.
	/// </summary>
	public class Vampire : Plugin
	{
		public Vampire()
		{
			// register resource manager
			AddResourceManager(Resources.ResourceManager);

			// create all the groups we need in the node explorer
			NodeGroup actions= new NodeGroup(Resources.NodeGroupActions, NodeIcon.Action, null);
			_nodeGroups.Add(actions);

			NodeGroup conditions= new NodeGroup(Resources.NodeGroupConditions, NodeIcon.Condition, null);
			_nodeGroups.Add(conditions);

			NodeGroup decorators= new NodeGroup(Resources.NodeGroupDecorators, NodeIcon.Decorator, null);
			_nodeGroups.Add(decorators);

			NodeGroup impulses= new NodeGroup(Resources.NodeGroupImpulses, NodeIcon.Impulse, null);
			_nodeGroups.Add(impulses);

			NodeGroup events= new NodeGroup(Resources.NodeGroupEvents, NodeIcon.Event, null);
			_nodeGroups.Add(events);

            NodeGroup composites = new NodeGroup(Resources.NodeGroupComposites, NodeIcon.Parallel, null);
            _nodeGroups.Add(composites);

			// create all the action nodes
            actions.Items.Add(typeof(Actions.Attack));
            actions.Items.Add(typeof(Actions.ChooseFarthestSkill));
            actions.Items.Add(typeof(Actions.ChooseRandomSkill));
            actions.Items.Add(typeof(Actions.ChooseTargetInView));
            actions.Items.Add(typeof(Actions.ChooseTargetWhoAttack));
            actions.Items.Add(typeof(Actions.EndFight));
            actions.Items.Add(typeof(Actions.MoveToAttackRange));


			// create all the condition nodes
            actions.Items.Add(typeof(Conditions.HasRoleInView));
            actions.Items.Add(typeof(Conditions.HasTarget));
            actions.Items.Add(typeof(Conditions.IsAttacked));


            // create all the decorator nodes
			decorators.Items.Add(typeof(Decorators.Not));
			decorators.Items.Add(typeof(Decorators.Loop));
			decorators.Items.Add(typeof(Decorators.Successful));

			// create all the impulse nodes
            //impulses.Items.Add(typeof(Impulses.Impulse));

			// create all the event nodes
			//events.Items.Add(typeof(Events.FocusDestroyed));
			//events.Items.Add(typeof(Events.UnitBuilt));
			//events.Items.Add(typeof(Events.UnitDestroyed));


            // create all the composite nodes
            composites.Items.Add(typeof(Composites.Selector));
            composites.Items.Add(typeof(Composites.Sequence));
            composites.Items.Add(typeof(Composites.Parallel));

			// register all the file managers
			_fileManagers.Add( new FileManagerInfo(typeof(Brainiac.Design.FileManagers.FileManagerXML), "Behaviour XML (*.xml)|*.xml", ".xml") );

			// register all the exporters
			//_exporters.Add( new ExporterInfo(typeof(Brainiac.Design.Exporters.ExporterCs), "C# Behavior Exporter (Assign Properties)", true, "C#Properties") );
			//_exporters.Add( new ExporterInfo(typeof(Brainiac.Design.Exporters.ExporterCsUseParameters), "C# Behavior Exporter (Use Parameters)", true, "C#Parameters") );
		}
	}
}
