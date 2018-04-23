# How to measure loading time on the server and client sides


This example illustrates two approaches:<br /><br />1. How to measure and display loading time on the sever using the System.Diagnostics.Stopwatch class:<br />CS:<br />


```cs
 Stopwatch sw = System.Diagnostics.Stopwatch.StartNew();
        //some operations
        sw.Stop();
        AddEventLog(String.Format("Page_Load, Time: {0}", sw.Elapsed.TotalMilliseconds));

 private void AddEventLog(string eventLog) {
        if (!String.IsNullOrEmpty(eventOrder))
            eventOrder += "<br/>";
        eventOrder += eventLog;
}
```


VB:<br />


```vb
....
 Private sw As Stopwatch = System.Diagnostics.Stopwatch.StartNew()
		'some operations
		sw.Stop()
		AddEventLog(String.Format("Page_Load, Time: {0}", sw.Elapsed.TotalMilliseconds))
...
Private Sub AddEventLog(ByVal eventLog As String)
		If (Not String.IsNullOrEmpty(eventOrder)) Then
			eventOrder &= "<br/>"
		End If
		eventOrder += eventLog
 End Sub
```


<br /> All results are passed to the client-side for demonstration purposes.<br /><br />2. How to measure rendering time on the client using JavaScript methods: <br />     1) On the first page load create a Date variable in the head section.  <br />     2) Handle the <a href="https://documentation.devexpress.com/#AspNet/DevExpressWebASPxGlobalEventsScriptsASPxClientGlobalEvents_ControlsInitializedtopic">ASPxClientGlobalEvents.ControlsInitialized</a> event raised after our controls were loaded to check time difference. <br />     3) I've overridden our internal aspxCallback function which is executed after the new result is applied from the client to define a start point on callbacks.<br /><br />


```js
   var start = new Date();
        function ge_ControlsInitialized(s, e) {
            if (e.isCallback == false)
            {
                var original = aspxCallback;
                aspxCallback = function (result, context) {
                    start = new Date(); 
                    original(result, context);
                }              
            }
            var end = new Date();
            var output = document.getElementById("output");
            output.innerHTML = "Loading time(in ms): " + (end - start);
        }
```



<br/>


