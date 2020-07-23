using System;
using System.Collections;

// Remoting libraries
using System.Runtime;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

// Nujit framework libraries
using Nujit.NujitERP.ClassLib.Common;
using Nujit.NujitERP.ClassLib.Core.Remote;
using Nujit.NujitERP.ClassLib.ErpException;
using Nujit.NujitERP.ClassLib.Core.Engine;

namespace Nujit.NujitERP.ClassLib.Core{

/// <summary>
/// UtilCoreFactory : Used for give access to System, is used for create instances of CoreFactory objects
/// They can be locals, server or remotes instances, depending on the configuration file
/// </summary>
public 
class UtilCoreFactory{

/// <summary>
/// Constants for determine the type of connection, valids are : Local, Server and Client
/// </summary>
public const string LOCAL = "Local";
public const string SERVER = "Server";
public const string CLIENT = "Client";

/// <summary>
/// Create and return an instance of CoreFactory, if the consumer are in the client-side, this method will return
/// an instance of RemoteCoreFactory, otherwise returns LocalCoreFactory
/// </summary>
/// <returns></returns>
public static
CoreFactory createCoreFactory(){
	return UtilCoreFactory.createCoreFactory(Configuration.RunMode);
}

/// <summary>
/// Create and return an instance of CoreFactory, depending on te parameter, this method will return
/// an instance of RemoteCoreFactory, otherwise returns LocalCoreFactory
/// </summary>
/// <param name="runMode"></param>
/// <returns></returns>
public static
CoreFactory createCoreFactory(string runMode){

	// local side : application runs stand-alone
	if (runMode.Equals(UtilCoreFactory.LOCAL)){
		LocalCoreFactory localCoreFactory = new LocalCoreFactory();
		
		Engine.Engine.getInstance(localCoreFactory);
		
		return (CoreFactory)localCoreFactory;
	}

	// server side : service provider
	if (runMode.Equals(UtilCoreFactory.SERVER)){
		LocalCoreFactory localCoreFactory = new LocalCoreFactory();

		Engine.Engine.getInstance(localCoreFactory);

		BinaryServerFormatterSinkProvider provider = new BinaryServerFormatterSinkProvider();
		provider.TypeFilterLevel = System.Runtime.Serialization.Formatters.TypeFilterLevel.Full;
		Hashtable props = new Hashtable();
		props.Add("port", int.Parse(Configuration.ServerPort));
		TcpChannel tcpChannel = new TcpChannel(props, null, provider);
		ChannelServices.RegisterChannel(tcpChannel);

		RemotingServices.Marshal(localCoreFactory, Configuration.ServiceName);

		System.Reflection.MethodInfo[] mis = ((object)localCoreFactory).GetType().GetMethods();
		for(int i = 0; i < mis.Length; i++){
			if (mis[i].IsPublic){
				RemotingConfiguration.RegisterWellKnownServiceType(
					typeof(ClassLib.Core.Remote.LocalCoreFactory), mis[i].Name, WellKnownObjectMode.SingleCall);
			}
		}

		return (CoreFactory)localCoreFactory;
	}

	// client side : service consumer
	if (runMode.Equals(UtilCoreFactory.CLIENT)){
		return new RemoteCoreFactory();
	}

	throw new NujitException("The string RunMode is wrong !!!!!!!!");
}

} // class

} // namespace
