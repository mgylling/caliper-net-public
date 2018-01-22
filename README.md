# caliper-net
IMS Global caliper-net
==============

# Overview

**caliper-net** is a .NET client for [Caliper](http://www.imsglobal.org/caliper) that provides an implementation of the Caliper SensorAPI™.

# Getting Started

First, instantiate a new Caliper Sensor, specifying a sensor ID (used to distinguish the source of events), then register a Caliper endpoint where events will be sent to.

> NOTE: The sensor object should be created once and reused when sending events over the course of an application lifetime.

```csharp
using ImsGlobal.Caliper;
...
var sensor = new CaliperSensor( "my-sensor-id" );
string endpointId = sensor.RegisterEndpoint(
    new CaliperEndpointOptions( "https://caliper.example.edu/events" )
);
```

Then create an event:

```csharp
using ImsGlobal.Caliper.Entities.Agent;
using ImsGlobal.Caliper.Entities.Media;
using ImsGlobal.Caliper.Events;
using ImsGlobal.Caliper.Events.Media;
using NodaTime;
...
var mediaEvent = new MediaEvent( Action.Paused ) {
	Actor = new Person( "https://example.edu/user/554433" ),
	Object = new VideoObject( "https://example.com/super-media-tool/video/1225" ),
	Target = new MediaLocation( "https://example.com/super-media-tool/video/1225" ) {
        CurrentTime = 710
    },
	EventTime = Instant.FromUtc( 2015, 9, 15, 10, 15, 0 ),
	EdApp = new SoftwareApplication( "https://example.com/super-media-tool" ) {
        Name = "Super Media Tool"
    }
};

```

Finally, send the event to the registered endpoint through the sensor:

```csharp
bool success = await sensor.SendAsync( mediaEvent );
```

## Sending a batch of events

You can send multiple events in one call to the Caliper endpoint:

```csharp
var events = new List<Event>();
events.add( event1 );
events.add( event2 );
events.add( event3 );

sensor.SendAsync( events );
```

## Sending events to multiple endpoints

You can register multiple endpoints with the sensor to send the same events to all registered endpoints:

```csharp
var sensor = new CaliperSensor( "my-sensor-id" );
string endpoint1 = sensor.RegisterEndpoint( new CaliperEndpointOptions( "https://caliper.example.edu/events" ) );
string endpoint2 = sensor.RegisterEndpoint( new CaliperEndpointOptions( "https://analytics.vendor.com/caliper" ) );

var @event = ...
sensor.SendAsync( @event ); // this event will be sent to both registered endpoints
```

## Sending events to one endpoint but not another

If you registered multiple endpoints, but want to send some events to some endpoints but not others, pass the endpoint ID during the `SendAsync` call:

```csharp
// register multiple endpoints as above

var @event = ...
sensor.SendAsync( @event, endpoint1 ); // this event will be sent to endpoint1 only
```

## Describing entities

The sensor provides a `Describe()` method to send entity descriptions to the Caliper endpoint:

```csharp
var entity = new VideoObject( "https://example.com/super-media-tool/video/1225" ) {
    Name = "American Revolution - Key Figures Video",
    AlignedLearningObjectives = new [] { 
        new LearningObjective( "https://example.edu/american-revolution-101/personalities/learn" )
    },
    Duration = 1420,
    Version = "1.0",
    DateCreated = Instant.FromUtc( 2015, 8, 1, 6, 0, 0 ),
    DateModified = Instant.FromUtc( 2015, 9, 2, 11, 30, 0 )
};

sensor.DescribeAsync( entity );
```

# Supported Metric Profiles
* Base MP
* Session MP
* Reading MP
* Annotation MP
* Assignable MP
* Assessment MP
* Assessment Item MP
* Outcome MP
* Media MP 

# Building

## Requirements
* .NET Framework 4.5
* (optional) Visual Studio 2013

## From Visual Studio
* Open the `ImsGlobal.Caliper.sln` solution in Visual Studio
* Select the desired build configuration: `Debug` or `Release`
* Build the `ImsGlobal.Caliper` project

## From the Command Line
```
> cd caliper-net
> msbuild ImsGlobal.Caliper.sln
```

By default this will use the `Debug` build configuration. To use the `Release` build configuration:

```
> msbuild ImsGlobal.Caliper.sln /property:Configuration=Release
```

The build output will be under `.\src\ImsGlobal.Caliper\bin\Debug` or `.src\ImsGlobal.Caliper\bin\Release`, depending on the chosen build configuration.

# Running Tests

```
> cd caliper-net
> .nuget\nuget.exe install NUnit.Runners -Version 2.6.4 -OutputDirectory packages
> packages\NUnit.Runners.2.6.4\tools\nunit-console.exe ^
    /config:Debug ^
    /framework:net-4.5 ^
    test\ImsGlobal.Caliper.Tests\bin\Debug\ImsGlobal.Caliper.Tests.dll

```

## Documentation

Documentation is available at [http://www.imsglobal.org/caliper](https://www.imsglobal.org/caliper).

© 2018 IMS Global Learning Consortium, Inc. All Rights Reserved. Trademark Information- http://www.imsglobal.org/copyright.html

For license information contact info@imsglobal.org and read the license file contained in the repository.
