using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Microsoft.Win32;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace ServerFront
{
     public class MainWindowViewModel/* : INotifyPropertyChanged*/
     {/*
         #region save
         bool _changedSinceLastSave;
         string _lastSavePath;
         /// <summary>
         /// Last path loaded/saved.
         /// </summary>
         public string OpenedFilePath
         {
             get
             {
                 return _lastSavePath;
             }
             private set
             {
                 if( value != _lastSavePath )
                 {
                     _lastSavePath = value;
                     RaisePropertyChanged();
                     RaisePropertyChanged( "WindowTitle" );
                 }
             }
         }

         private void AutosaveTick( object sender, EventArgs e )
        {
            Autosave();
        }

         /// <summary>
         /// Remove any existing autosave.
         /// </summary>
         public void ClearAutosave()
         {
             Yodii.Lab.Properties.Settings.Default.LastAutosaveFilePath = String.Empty;
             Yodii.Lab.Properties.Settings.Default.LastAutosaveFileContents = String.Empty;

             Yodii.Lab.Properties.Settings.Default.Save();
         }

        private void Autosave()
        {
            if( !ChangedSinceLastSave ) return;

            string xmlString;

            UpdateGraphPositions();

            using( StringWriter sw = new StringWriter() )
            {
                using( XmlWriter xw = XmlWriter.Create( sw ) )
                {
                    try
                    {
                        xw.WriteStartDocument( true );
                        LabXmlSerialization.SerializeToXml( LabState, xw );
                        xw.WriteEndDocument();
                    }
                    catch( Exception ex )
                    {
                        MessageBox.Show(
                            String.Format( "Autosave failed:\n{0}\n\n{1}", ex.Message, ex.StackTrace ),
                            "Autosave failed",
                            MessageBoxButton.OK, MessageBoxImage.Error,
                            MessageBoxResult.OK
                            );

                    }
                }

                xmlString = sw.ToString();
            }

            Yodii.Lab.Properties.Settings.Default.LastAutosaveFileContents = xmlString;
            if( String.IsNullOrWhiteSpace( OpenedFilePath ) )
            {
                Yodii.Lab.Properties.Settings.Default.LastAutosaveFilePath = String.Empty;
            }
            else
            {
                Yodii.Lab.Properties.Settings.Default.LastAutosaveFilePath = OpenedFilePath;
            }

            Yodii.Lab.Properties.Settings.Default.Save();
        }

        /// <summary>
        /// In case the file changed, attempts to save the last file.
        /// </summary>
        /// <returns>True if save was successful. False if save failed, or was canceled.</returns>
        private bool Save()
        {
            if( !String.IsNullOrWhiteSpace( OpenedFilePath ) )
            {
                var r = SaveState( OpenedFilePath );
                if( !r )
                {
                    MessageBox.Show( r.Reason, "Couldn't save file" );
                }
                return r.IsSuccessful;
            }
            else
            {
                return SaveAs();
            }
        }

        private bool SaveAs()
        {
            string saveFilePath = SelectSaveFile();

            if( saveFilePath != null )
            {
                var r = SaveState( saveFilePath );
                if( !r )
                {
                    MessageBox.Show( r.Reason, "Couldn't save file" );
                }
                else
                {
                    return true;
                }
            }
            return false;
        }

        private string SelectSaveFile()
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.DefaultExt = ".xml";
            dlg.Filter = "Yodii.Lab XML Files (*.xml)|*.xml";
            dlg.CheckPathExists = true;
            dlg.OverwritePrompt = true;
            dlg.AddExtension = true;
            dlg.FileName = OpenedFilePath;
            bool? result = dlg.ShowDialog();
            return result == true ? dlg.FileName : null;
        }
        /// <summary>
        /// Saves the lab state to a file.
        /// </summary>
        /// <param name="filePath">XML file to use</param>
        /// <returns>Operation result</returns>
        public DetailedOperationResult SaveState( string filePath )
        {

            XmlWriterSettings ws = new XmlWriterSettings();
            ws.NewLineHandling = NewLineHandling.None;
            ws.Indent = true;

            //UpdateGraphPositions();

            try
            {
                using( FileStream fs = File.Open( filePath, FileMode.Create ) )
                {
                    using( XmlWriter xw = XmlWriter.Create( fs, ws ) )
                    {
                        xw.WriteStartDocument( true );
                        LabXmlSerialization.SerializeToXml( LabState, xw );
                        xw.WriteEndDocument();
                    }
                }
                ChangedSinceLastSave = false;
                OpenedFilePath = filePath;
                ClearAutosave();
                RaiseCloseBackstageRequest();
            }
            catch( Exception e ) // TODO: Detailed exception handling
            {
                return new DetailedOperationResult( false, e.Message );
            }


            RaiseNewNotification( new Notification() { Title = "Saved state", Message = filePath } );
            return new DetailedOperationResult( true );
        }
        #endregion

        #region InotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged( [CallerMemberName] string caller = null )
        {
            Debug.Assert( caller != null );
            if( PropertyChanged != null )
            {
                PropertyChanged( this, new PropertyChangedEventArgs( caller ) );
            }
        }
        #endregion
    }
     public class DetailedOperationResult
     {
         /// <summary>
         /// Description of the reason behind the operation success/failure.
         /// </summary>
         public string Reason { get; private set; }

         /// <summary>
         /// Whather the operation was successful.
         /// </summary>
         public bool IsSuccessful { get; private set; }

         /// <summary>
         /// Creates a new instance of DetailedOperationResult.
         /// </summary>
         /// <param name="isSuccessful">Whether the operation was successful.</param>
         /// <param name="reason">Reason behind the operation.</param>
         public DetailedOperationResult( bool isSuccessful = true, string reason = "" )
         {
             Reason = reason;
             IsSuccessful = isSuccessful;
         }

         /// <summary>
         /// Implicit bool operator.
         /// </summary>
         /// <param name="result">object to consider</param>
         /// <returns>True if result is successful.</returns>
         public static implicit operator bool( DetailedOperationResult result )
         {
             return result.IsSuccessful;
         }
     }

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows;
using System.Xml;
using CK.Core;
using Yodii.Lab.Mocks;
using Yodii.Model;

namespace Yodii.Lab
{
    static class LabXmlSerialization
    {
        public static void SerializeToXml( LabStateManager state, XmlWriter w )
        {
            PersistedLabState stateToSerialize = CreatePersistentObject( state );

            w.WriteStartElement( "Yodii.Lab" );

            w.WriteStartElement( "Services" );
            foreach( ServiceInfo si in state.ServiceInfos )
            {
                w.WriteStartElement( "Service" );
                SerializeServiceInfoToXmlWriter( si, w );
                w.WriteEndElement();
            }
            w.WriteEndElement();

            w.WriteStartElement( "Plugins" );
            foreach( PluginInfo pi in state.PluginInfos )
            {
                w.WriteStartElement( "Plugin" );
                SerializePluginInfoToXmlWriter( pi, w );
                w.WriteEndElement();
            }
            w.WriteEndElement();

            w.WriteStartElement( "Configuration" );
            SerializeConfigurationManager( stateToSerialize, w );
            w.WriteEndElement();

            w.WriteEndElement();
        }

        public static void DeserializeAndResetStateFromXml( this LabStateManager state, XmlReader r )
        {
            LabXmlDeserializer helper = new LabXmlDeserializer( state, r );
            helper.Deserialize();
        }

        #region Conversion & application of persisted classes
        private static PersistedLabState CreatePersistentObject( LabStateManager runningState )
        {
            PersistedLabState persistedState = new PersistedLabState();

            // Persist layer
            foreach( IConfigurationLayer l in runningState.Engine.Configuration.Layers )
            {
                PersistedConfigurationLayer persistedLayer = new PersistedConfigurationLayer();
                persistedState.ConfigurationLayers.Add( persistedLayer );

                persistedLayer.LayerName = l.LayerName;
                foreach( IConfigurationItem i in l.Items )
                {
                    PersistedConfigurationItem persistedItem = new PersistedConfigurationItem();
                    persistedItem.ServiceOrPluginId = i.ServiceOrPluginFullName;
                    persistedItem.Status = i.Status;
                    persistedItem.StatusReason = i.StatusReason;

                    persistedLayer.Items.Add( persistedItem );
                }
            }

            // Persist service and plugins -- We already have the mocks, so we can use them.
            foreach( ServiceInfo s in runningState.ServiceInfos )
            {
                persistedState.Services.Add( s );
            }
            foreach( PluginInfo p in runningState.PluginInfos )
            {
                persistedState.Plugins.Add( p );
            }

            return persistedState;
        }
        #endregion

        #region Serialization
        private static void SerializeConfigurationManager( PersistedLabState s, XmlWriter w )
        {
            foreach( var layer in s.ConfigurationLayers )
            {
                w.WriteStartElement( "ConfigurationLayer" );

                w.WriteStartAttribute( "Name" );
                w.WriteValue( layer.LayerName );
                w.WriteEndAttribute();

                foreach( var item in layer.Items )
                {
                    w.WriteStartElement( "ConfigurationItem" );

                    w.WriteStartAttribute( "ServiceOrPluginId" );
                    w.WriteValue( item.ServiceOrPluginId );
                    w.WriteEndAttribute();

                    w.WriteStartAttribute( "Status" );
                    w.WriteValue( item.Status.ToString() );
                    w.WriteEndAttribute();

                    w.WriteStartAttribute( "Reason" );
                    w.WriteValue( item.StatusReason );
                    w.WriteEndAttribute();

                    w.WriteEndElement();
                }

                w.WriteEndElement();
            }
        }

        private static void SerializeServiceInfoToXmlWriter( ServiceInfo si, XmlWriter w )
        {
            w.WriteStartAttribute( "FullName" );
            w.WriteValue( si.ServiceFullName );
            w.WriteEndAttribute();

            w.WriteStartElement( "Generalization" );
            if( si.Generalization != null ) w.WriteValue( si.Generalization.ServiceFullName );
            w.WriteEndElement();

            // That's pretty much all we need. Implementations will be guessed from the plugins themselves.
            // HasError, AssemblyInfo and others aren't supported at this time, but can be added here later on.

            w.WriteStartElement( "X" );
            if( si.PositionInGraph.IsValid() ) w.WriteValue( si.PositionInGraph.X.ToString( CultureInfo.InvariantCulture ) );
            w.WriteEndElement();

            w.WriteStartElement( "Y" );
            if( si.PositionInGraph.IsValid() ) w.WriteValue( si.PositionInGraph.Y.ToString( CultureInfo.InvariantCulture ) );
            w.WriteEndElement();
        }

        private static void SerializePluginInfoToXmlWriter( PluginInfo pi, XmlWriter w )
        {
            w.WriteStartElement( "FullName" );
            if( pi.PluginFullName != null ) w.WriteValue( pi.PluginFullName );
            w.WriteEndElement();

            w.WriteStartElement( "Service" );
            if( pi.Service != null ) w.WriteValue( pi.Service.ServiceFullName );
            w.WriteEndElement();

            w.WriteStartElement( "ServiceReferences" );
            foreach( var serviceRef in pi.ServiceReferences )
            {
                Debug.Assert( serviceRef.Owner == pi );

                w.WriteStartElement( "ServiceReference" );

                w.WriteStartAttribute( "Service" );
                w.WriteValue( serviceRef.Reference.ServiceFullName );
                w.WriteEndAttribute();

                w.WriteStartAttribute( "Requirement" );
                w.WriteValue( serviceRef.Requirement.ToString() );
                w.WriteEndAttribute();

                w.WriteEndElement();
            }
            w.WriteEndElement();

            w.WriteStartElement( "X" );
            if( pi.PositionInGraph.IsValid() ) w.WriteValue( pi.PositionInGraph.X.ToString( CultureInfo.InvariantCulture ) );
            w.WriteEndElement();

            w.WriteStartElement( "Y" );
            if( pi.PositionInGraph.IsValid() ) w.WriteValue( pi.PositionInGraph.Y.ToString( CultureInfo.InvariantCulture ) );
            w.WriteEndElement();
        }
        #endregion

    }

    class LabXmlDeserializer
    {
        CKSortedArrayKeyList<ServiceInfo, string> loadedServices;
        CKSortedArrayKeyList<PluginInfo, string> loadedPlugins;
        List<PendingGeneralization> pendingGeneralizations;
        List<PendingPluginService> pendingPluginServices;
        List<PendingServiceReference> pendingServiceReferences;
        LabStateManager state;
        PersistedLabState deserializedState;
        XmlReader r;


        internal LabXmlDeserializer( LabStateManager state, XmlReader r )
        {
            this.state = state;
            this.r = r;
            deserializedState = new PersistedLabState();
            // Used to index reference links between plugins and services.
            pendingGeneralizations = new List<PendingGeneralization>();
            pendingPluginServices = new List<PendingPluginService>();
            pendingServiceReferences = new List<PendingServiceReference>();

            loadedServices = new CKSortedArrayKeyList<ServiceInfo, string>( s => s.ServiceFullName, false );
            loadedPlugins = new CKSortedArrayKeyList<PluginInfo, string>( p => p.PluginFullName, false );
        }

        internal void Deserialize()
        {
            if( state.Engine.IsRunning )
            {
                state.Engine.Stop();
            }

            while( r.Read() )
            {
                // Load services
                if( r.IsStartElement() && r.Name == "Services" )
                {
                    ReadServices( r.ReadSubtree() );
                }

                // Load plugins
                if( r.IsStartElement() && r.Name == "Plugins" )
                {
                    ReadPlugins( r.ReadSubtree() );
                }

                // Read configuration manager
                if( r.IsStartElement() && r.Name == "Configuration" )
                {
                    ReadConfigurationManager( r.ReadSubtree() );
                }
            }

            foreach( var s in loadedServices )
            {
                deserializedState.Services.Add( s );
            }
            foreach( var p in loadedPlugins )
            {
                deserializedState.Plugins.Add( p );
            }

            ApplyPersistedStateToLab();
        }

        private void ReadConfigurationManager( XmlReader r )
        {
            // We're already inside a Configuration Element.

            while( r.Read() )
            {
                if( r.IsStartElement() && r.Name == "ConfigurationLayer" )
                {
                    var newLayer = DeserializeConfigurationLayer( r.ReadSubtree() );
                    deserializedState.ConfigurationLayers.Add( newLayer );
                }
            }
        }

        private PersistedConfigurationLayer DeserializeConfigurationLayer( XmlReader r )
        {
            PersistedConfigurationLayer newLayer = new PersistedConfigurationLayer();

            // We're already inside a ConfigurationLayer element.
            r.Read();
            newLayer.LayerName = r.GetAttribute( "Name" );

            while( r.Read() )
            {
                if( r.IsStartElement() && r.Name == "ConfigurationItem" )
                {
                    PersistedConfigurationItem item = new PersistedConfigurationItem();
                    item.ServiceOrPluginId = r.GetAttribute( "ServiceOrPluginId" );
                    item.Status = (ConfigurationStatus)Enum.Parse( typeof( ConfigurationStatus ), r.GetAttribute( "Status" ) );
                    item.StatusReason = r.GetAttribute( "Reason" );

                    newLayer.Items.Add( item );
                }
            }

            return newLayer;
        }

        private void ReadServices( XmlReader r )
        {
            while( r.Read() )
            {
                if( r.IsStartElement() && r.Name == "Service" )
                {
                    ReadService( r.ReadSubtree() );
                }
            }
        }

        private void ReadService( XmlReader r )
        {
            r.Read();
            string serviceFullName = r.GetAttribute( "FullName" );
            Debug.Assert( serviceFullName != null, "FullName attribute was found in Service XML element." );

            ServiceInfo s = new ServiceInfo( serviceFullName, AssemblyInfoHelper.ExecutingAssemblyInfo );
            loadedServices.Add( s );

            ServiceInfo generalization = null;

            Point pos = new Point();
            pos.X = Double.NaN;
            pos.Y = Double.NaN;

            while( r.Read() )
            {
                if( r.IsStartElement() && !r.IsEmptyElement )
                {
                    switch( r.Name )
                    {
                        case "Generalization":
                            if( r.Read() )
                            {
                                string generalizationName = r.Value;
                                if( !String.IsNullOrEmpty( generalizationName ) )
                                {
                                    if( loadedServices.Contains( generalizationName ) )
                                    {
                                        generalization = loadedServices.GetByKey( generalizationName );
                                        s.Generalization = generalization;
                                    }
                                    else
                                    {
                                        pendingGeneralizations.Add( new PendingGeneralization( s, generalizationName ) );
                                    }
                                }
                            }
                            break;
                        case "X":
                            if( r.Read() )
                            {
                                double posX;
                                if( Double.TryParse( r.Value, NumberStyles.Any, CultureInfo.InvariantCulture, out posX ) ) pos.X = posX;
                            }
                            break;
                        case "Y":
                            if( r.Read() )
                            {
                                double posY;
                                if( Double.TryParse( r.Value, NumberStyles.Any, CultureInfo.InvariantCulture, out posY ) ) pos.Y = posY;
                            }
                            break;
                    }
                }
            }

            s.PositionInGraph = pos;

            // Fix pending references of this service
            foreach( var pg in pendingGeneralizations.Where( x => x.PendingServiceFullName == serviceFullName ).ToList() )
            {
                pg.Service.Generalization = s;
                pendingGeneralizations.Remove( pg );
            }

            foreach( var pps in pendingPluginServices.Where( x => x.PendingServiceFullName == serviceFullName ).ToList() )
            {
                pps.Plugin.Service = s;
                s.InternalImplementations.Add( pps.Plugin );
                pendingPluginServices.Remove( pps );
            }

            foreach( var psr in pendingServiceReferences.Where( x => x.PendingServiceFullName == serviceFullName ).ToList() )
            {
                var reference = new MockServiceReferenceInfo( psr.Plugin, s, psr.Requirement );
                psr.Plugin.InternalServiceReferences.Add( reference );
                pendingServiceReferences.Remove( psr );
            }
        }

        private void ReadPlugins( XmlReader r )
        {
            while( r.Read() )
            {
                if( r.IsStartElement() && r.Name == "Plugin" )
                {
                    ReadPlugin( r.ReadSubtree() );
                }
            }
        }

        private void ReadPlugin( XmlReader r )
        {
            r.Read();

            PluginInfo p = new PluginInfo( null, AssemblyInfoHelper.ExecutingAssemblyInfo );
            loadedPlugins.Add( p );

            Point pos = new Point();
            pos.X = Double.NaN;
            pos.Y = Double.NaN;

            while( r.Read() )
            {
                if( r.IsStartElement() && !r.IsEmptyElement )
                {
                    switch( r.Name )
                    {
                        case "FullName":
                            if( r.Read() )
                            {
                                string fullName = r.Value;
                                p.PluginFullName = fullName;
                            }
                            break;
                        case "Service":
                            if( r.Read() )
                            {
                                string serviceFullName = r.Value;
                                if( !String.IsNullOrEmpty( serviceFullName ) )
                                {
                                    if( loadedServices.Contains( serviceFullName ) )
                                    {
                                        var service = loadedServices.GetByKey( serviceFullName );
                                        p.Service = service;
                                        service.InternalImplementations.Add( p );
                                    }
                                    else
                                    {
                                        pendingPluginServices.Add( new PendingPluginService( p, serviceFullName ) );
                                    }
                                }
                            }
                            break;
                        case "ServiceReferences":
                            var s = r.ReadSubtree();
                            while( s.Read() )
                            {
                                if( s.IsStartElement() && s.Name == "ServiceReference" )
                                {
                                    string serviceFullName2 = s.GetAttribute( "Service" );
                                    if( !String.IsNullOrEmpty( serviceFullName2 ) )
                                    {
                                        DependencyRequirement requirement = (DependencyRequirement)Enum.Parse( typeof( DependencyRequirement ), s.GetAttribute( "Requirement" ) );

                                        if( loadedServices.Contains( serviceFullName2 ) )
                                        {
                                            MockServiceReferenceInfo i = new MockServiceReferenceInfo( p, loadedServices.GetByKey( serviceFullName2 ), requirement );
                                            p.InternalServiceReferences.Add( i );
                                        }
                                        else
                                        {
                                            pendingServiceReferences.Add( new PendingServiceReference( p, serviceFullName2, requirement ) );
                                        }
                                    }
                                }
                            }
                            break;
                        case "X":
                            if( r.Read() )
                            {
                                double posX;
                                if( Double.TryParse( r.Value, NumberStyles.Any, CultureInfo.InvariantCulture, out posX) ) pos.X = posX;
                            }
                            break;
                        case "Y":
                            if( r.Read() )
                            {
                                double posY;
                                if( Double.TryParse( r.Value, NumberStyles.Any, CultureInfo.InvariantCulture, out posY ) ) pos.Y = posY;
                            }
                            break;
                    }
                }
            }

            p.PositionInGraph = pos;
        }

        private void ApplyPersistedStateToLab()
        {
            // Stop running engine
            if( state.Engine.IsRunning )
            {
                state.Engine.Stop();
            }

            // Clear configuration manager
            foreach( var l in state.Engine.Configuration.Layers.ToList() )
            {
                var result = state.Engine.Configuration.Layers.Remove( l );
                Debug.Assert( result.Success );
            }

            // Clear services and plugins
            state.ClearState();

            // Add services and plugins
            foreach( ServiceInfo s in deserializedState.Services )
            {
                state.LoadServiceInfo( s );
            }
            foreach( PluginInfo p in deserializedState.Plugins )
            {
                state.LoadPluginInfo( p );
            }

            // Load configuration manager data
            foreach( PersistedConfigurationLayer l in deserializedState.ConfigurationLayers )
            {
                IConfigurationLayer newLayer = state.Engine.Configuration.Layers.Create( l.LayerName );

                foreach( PersistedConfigurationItem item in l.Items )
                {
                    var result = newLayer.Items.Add( item.ServiceOrPluginId, item.Status, item.StatusReason );
                    Debug.Assert( result.Success );
                }
            }
        }

    }

    #region Persistent state classes

    class PersistedLabState
    {
        public List<PersistedConfigurationLayer> ConfigurationLayers { get; private set; }
        public List<ServiceInfo> Services { get; private set; }
        public List<PluginInfo> Plugins { get; private set; }

        public PersistedLabState()
        {
            ConfigurationLayers = new List<PersistedConfigurationLayer>();
            Services = new List<ServiceInfo>();
            Plugins = new List<PluginInfo>();
        }
    }

    class PersistedConfigurationLayer
    {
        public string LayerName { get; set; }
        public List<PersistedConfigurationItem> Items { get; private set; }

        internal PersistedConfigurationLayer()
        {
            Items = new List<PersistedConfigurationItem>();
        }
    }

    class PersistedConfigurationItem
    {
        public string ServiceOrPluginId { get; set; }
        public ConfigurationStatus Status { get; set; }
        public string StatusReason { get; set; }
    }
    #endregion*/
}

    
}
