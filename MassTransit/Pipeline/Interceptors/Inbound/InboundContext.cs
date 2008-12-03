// Copyright 2007-2008 The Apache Software Foundation.
//  
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use 
// this file except in compliance with the License. You may obtain a copy of the 
// License at 
// 
//     http://www.apache.org/licenses/LICENSE-2.0 
// 
// Unless required by applicable law or agreed to in writing, software distributed 
// under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
// CONDITIONS OF ANY KIND, either express or implied. See the License for the 
// specific language governing permissions and limitations under the License.
namespace MassTransit.Pipeline.Interceptors.Inbound
{
	using System;
	using System.Collections.Generic;

	public class InboundContext :
		IInboundContext
	{
		private readonly InboundPipeline _pipeline;
		private readonly HashSet<Type> _used = new HashSet<Type>();

		public InboundContext(InboundPipeline pipeline)
		{
			_pipeline = pipeline;
		}

		public MessagePipeline Pipeline
		{
			get { return _pipeline; }
		}

		public bool HasMessageTypeBeenDefined(Type messageType)
		{
			return _used.Contains(messageType);
		}

		public void MessageTypeWasDefined(Type messageType)
		{
			_used.Add(messageType);
		}

		public IObjectBuilder Builder
		{
			get { return _pipeline.Builder; }
		}
	}
}