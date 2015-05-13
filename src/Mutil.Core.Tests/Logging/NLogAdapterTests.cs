using Mutil.Core.Logging;
using NLog;
using NLog.Config;
using NLog.Targets;
using System;
using System.IO;
using System.Xml;
using Xunit;

namespace Mutil.Core.Tests.Logging
{
    // Tests should be greatly improved and cleaned.

    public class NLogAdapterTests
    {
        [Fact]
        public void Error()
        {
            LogManager.Configuration = CreateConfigurationFromString(@"
                <nlog>
                    <targets><target name='debug' type='Debug' layout='${message}' /></targets>
                    <rules>
                        <logger name='test' level='error' writeTo='debug' />
                    </rules>
                </nlog>");

            var logger = new NLogAdapter(LogManager.GetLogger("test"));

            var errorMessage = "testerror";
            logger.Error(errorMessage);

            AssertDebugLastMessageContains("debug", errorMessage);
        }

        // Methods below are taken from https://github.com/NLog/NLog/blob/master/tests/NLog.UnitTests/NLogTestBase.cs
        public void AssertDebugLastMessageContains(string targetName, string msg)
        {
            string debugLastMessage = GetDebugLastMessage(targetName);
            Assert.True(debugLastMessage.Contains(msg),
                string.Format("Expected to find '{0}' in last message value on '{1}', but found '{2}'", msg, targetName, debugLastMessage));
        }

        public string GetDebugLastMessage(string targetName)
        {
            return GetDebugLastMessage(targetName, LogManager.Configuration);
        }

        public string GetDebugLastMessage(string targetName, LoggingConfiguration configuration)
        {
            return GetDebugTarget(targetName, configuration).LastMessage;
        }

        public DebugTarget GetDebugTarget(string targetName)
        {
            return GetDebugTarget(targetName, LogManager.Configuration);
        }

        public DebugTarget GetDebugTarget(string targetName, LoggingConfiguration configuration)
        {
            var debugTarget = (DebugTarget)configuration.FindTargetByName(targetName);
            Assert.NotNull(debugTarget);
            return debugTarget;
        }

        protected XmlLoggingConfiguration CreateConfigurationFromString(string configXml)
        {
            using (var strReader = new StringReader(configXml))
            {
                using (var xmlReader = XmlReader.Create(strReader))
                {
                    //var doc = new XmlDocument();
                    //doc.LoadXml(configXml);
                    return new XmlLoggingConfiguration(xmlReader, Environment.CurrentDirectory);
                }
            }

        }
    }
}
