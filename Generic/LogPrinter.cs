using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class LogPrinter : MonoBehaviour 
{
	private const string WARNING_COLOR = "<color=yellow>";
	private const string LOG_COLOR = "<color=green>";
	private const string EXCEPTION_COLOR = "<color=red>";
	private const string ASSERT_COLOR = "<color=red>";
	private const string ERROR_COLOR = "<color=red>";
	private const string END_COLOR = "</color>";


	[SerializeField] Text debugText;
	[SerializeField] bool displayWarnings;
	[SerializeField] bool displayLogs;
	[SerializeField] bool displayExceptions;
	[SerializeField] bool displayAsserts;
	[SerializeField] bool displayErrors;
	[SerializeField] int maxLines = 3;

	[SerializeField] List<string> debugStrings = new List<string>();

	private void OnEnable()
	{
		debugText.text = "";
		Application.RegisterLogCallback(HandleLog);
		debugStrings.Clear();
		debugText.supportRichText = true;
	}

	private void OnDisable()
	{
		Application.RegisterLogCallback(null);
	}

	private void HandleLog(string logString, string type, LogType logType)
	{

		bool enterLog = false;
		switch(logType) {
		case LogType.Assert:
			if(displayAsserts) {
				enterLog = true;
			}
			break;
		case LogType.Error:
			if(displayErrors) {
				enterLog = true;
			}
			break;
		case LogType.Exception:
			if(displayExceptions) {
				enterLog = true;
			}
			break;
		case LogType.Log:
			if(displayLogs) {
				enterLog = true;
			}
			break;
		case LogType.Warning:
			if(displayWarnings) {
				enterLog = true;
			}
			break;
		}

		if(enterLog) {
			AddLine(GetColor(logType) + type + logString + END_COLOR);
		}
	}

	private void AddLine(string logString)
	{
		if(debugStrings.Count > maxLines) {
			debugStrings.RemoveAt(0);
		}

		debugStrings.Add(logString);
		PrintToConsole();
	}

	private void PrintToConsole()
	{
		string output = "";
		for (int i = 0; i < debugStrings.Count; i++) {
			output += debugStrings[i] + "\n";
		}

		debugText.text = output;
	}

	private string GetColor(LogType logType)
	{
		switch(logType)
		{
		case LogType.Assert:
			return ASSERT_COLOR;
		case LogType.Error:
			return ERROR_COLOR;
		case LogType.Exception:
			return EXCEPTION_COLOR;
		case LogType.Log:
			return LOG_COLOR;
		case LogType.Warning:
			return WARNING_COLOR;
		}

		return LOG_COLOR;
	}
}
