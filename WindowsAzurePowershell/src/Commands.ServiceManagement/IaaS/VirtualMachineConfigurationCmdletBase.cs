﻿// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS
{
    using System.Linq;
    using System.Management.Automation;
    using Model;
    using Model.PersistentVMModel;

    public class VirtualMachineConfigurationCmdletBase : PSCmdlet
    {
        protected const string StaticVNetIPNoun = "AzureStaticVNetIP";

        [Parameter(Position = 0, Mandatory = true, ValueFromPipeline = true, HelpMessage = "Virtual Machine to update.")]
        [ValidateNotNullOrEmpty]
        [Alias("InputObject")]
        public IPersistentVM VM
        {
            get;
            set;
        }

        protected NetworkConfigurationSet GetNetworkConfiguration()
        {
            var vm = VM.GetInstance();
            if (vm != null & vm.ConfigurationSets != null)
            {
                return vm.ConfigurationSets.OfType<NetworkConfigurationSet>().SingleOrDefault();
            }

            return null;
        }
    }
}
