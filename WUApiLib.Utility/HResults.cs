using System.ComponentModel;
using System.Reflection;

namespace WUApiLib.Utility
{
    /// <summary>
    /// Appendix G: Windows Update Agent Result Codes
    /// https://docs.microsoft.com/en-us/security-updates/windowsupdateservices/18128076
    /// WUA Success and Error Codes
    /// https://docs.microsoft.com/en-us/windows/win32/wua_sdk/wua-success-and-error-codes-
    /// </summary>
    public enum HResult : uint
    {
        [Description("Windows Update Agent was stopped successfully.")]
        WU_S_SERVICE_STOP = 0x240001,
        [Description("Windows Update Agent updated itself.")]
        WU_S_SELFUPDATE = 0x240002,
        [Description("Operation completed successfully but there were errors applying the updates..")]
        WU_S_UPDATE_ERROR = 0x240003,
        [Description("A callback was marked to be disconnected later because the request to disconnect the operation came while a callback was executing.")]
        WU_S_MARKED_FOR_DISCONNECT = 0x240004,
        [Description("The system must be restarted to complete installation of the update.")]
        WU_S_REBOOT_REQUIRED = 0x240005,
        [Description("The update to be installed is already installed on the system.")]
        WU_S_ALREADY_INSTALLED = 0x240006,
        [Description("The update to be removed is not installed on the system.")]
        WU_S_ALREADY_UNINSTALLED = 0x240007,
        [Description("The update to be downloaded has already been downloaded.")]
        WU_S_ALREADY_DOWNLOADED = 0x240008,
        [Description("Windows Update Agent was unable to provide the service.")]
        WU_E_NO_SERVICE = 0x80240001,
        [Description("The maximum capacity of the service was exceeded.")]
        WU_E_MAX_CAPACITY_REACHED = 0x80240002,
        [Description("An ID cannot be found.")]
        WU_E_UNKNOWN_ID = 0x80240003,
        [Description("The object could not be initialized.")]
        WU_E_NOT_INITIALIZED = 0x80240004,
        [Description("The update handler requested a byte range overlapping a previously requested range.")]
        WU_E_RANGEOVERLAP = 0x80240005,
        [Description("The requested number of byte ranges exceeds the maximum number (2^31 - 1).")]
        WU_E_TOOMANYRANGES = 0x80240006,
        [Description("The index to a collection was invalid.")]
        WU_E_INVALIDINDEX = 0x80240007,
        [Description("The key for the item queried could not be found.")]
        WU_E_ITEMNOTFOUND = 0x80240008,
        [Description("Another conflicting operation was in progress. Some operations such as installation cannot be performed twice simultaneously.")]
        WU_E_OPERATIONINPROGRESS = 0x80240009,
        [Description("Cancellation of the operation was not allowed.")]
        WU_E_COULDNOTCANCEL = 0x8024000A,
        [Description("Operation was cancelled.")]
        WU_E_CALL_CANCELLED = 0x8024000B,
        [Description("No operation was required.")]
        WU_E_NOOP = 0x8024000C,
        [Description("Windows Update Agent could not find required information in the update's XML data.")]
        WU_E_XML_MISSINGDATA = 0x8024000D,
        [Description("Windows Update Agent found invalid information in the update's XML data.")]
        WU_E_XML_INVALID = 0x8024000E,
        [Description("Circular update relationships were detected in the metadata.")]
        WU_E_CYCLE_DETECTED = 0x8024000F,
        [Description("Update relationships too deep to evaluate were evaluated.")]
        WU_E_TOO_DEEP_RELATION = 0x80240010,
        [Description("An invalid update relationship was detected.")]
        WU_E_INVALID_RELATIONSHIP = 0x80240011,
        [Description("An invalid registry value was read.")]
        WU_E_REG_VALUE_INVALID = 0x80240012,
        [Description("Operation tried to add a duplicate item to a list.")]
        WU_E_DUPLICATE_ITEM = 0x80240013,
        [Description("Operation tried to install while another installation was in progress or the system was pending a mandatory restart.")]
        WU_E_INSTALL_NOT_ALLOWED = 0x80240016,
        [Description("Operation was not performed because there are no applicable updates.")]
        WU_E_NOT_APPLICABLE = 0x80240017,
        [Description("Operation failed because a required user token is missing.")]
        WU_E_NO_USERTOKEN = 0x80240018,
        [Description("An exclusive update cannot be installed with other updates at the same time.")]
        WU_E_EXCLUSIVE_INSTALL_CONFLICT = 0x80240019,
        [Description("A policy value was not set.")]
        WU_E_POLICY_NOT_SET = 0x8024001A,
        [Description("The operation could not be performed because the Windows Update Agent is self-updating.")]
        WU_E_SELFUPDATE_IN_PROGRESS = 0x8024001B,
        [Description("An update contains invalid metadata.")]
        WU_E_INVALID_UPDATE = 0x8024001D,
        [Description("Operation did not complete because the service or system was being shut down.")]
        WU_E_SERVICE_STOP = 0x8024001E,
        [Description("Operation did not complete because the network connection was unavailable.")]
        WU_E_NO_CONNECTION = 0x8024001F,
        [Description("Operation did not complete because there is no logged-on interactive user.")]
        WU_E_NO_INTERACTIVE_USER = 0x80240020,
        [Description("Operation did not complete because it timed out.")]
        WU_E_TIME_OUT = 0x80240021,
        [Description("Operation failed for all the updates.")]
        WU_E_ALL_UPDATES_FAILED = 0x80240022,
        [Description("The license terms for all updates were declined.")]
        WU_E_EULAS_DECLINED = 0x80240023,
        [Description("There are no updates.")]
        WU_E_NO_UPDATE = 0x80240024,
        [Description("Group Policy settings prevented access to Windows Update.")]
        WU_E_USER_ACCESS_DISABLED = 0x80240025,
        [Description("The type of update is invalid.")]
        WU_E_INVALID_UPDATE_TYPE = 0x80240026,
        [Description("The URL exceeded the maximum length.")]
        WU_E_URL_TOO_LONG = 0x80240027,
        [Description("The update could not be uninstalled because the request did not originate from a WSUS server.")]
        WU_E_UNINSTALL_NOT_ALLOWED = 0x80240028,
        [Description("Search may have missed some updates before there is an unlicensed application on the system.")]
        WU_E_INVALID_PRODUCT_LICENSE = 0x80240029,
        [Description("A component required to detect applicable updates was missing.")]
        WU_E_MISSING_HANDLER = 0x8024002A,
        [Description("An operation did not complete because it requires a newer version of server.")]
        WU_E_LEGACYSERVER = 0x8024002B,
        [Description("A delta-compressed update could not be installed because it required the source.")]
        WU_E_BIN_SOURCE_ABSENT = 0x8024002C,
        [Description("A full-file update could not be installed because it required the source.")]
        WU_E_SOURCE_ABSENT = 0x8024002D,
        [Description("Access to an unmanaged server is not allowed.")]
        WU_E_WU_DISABLED = 0x8024002E,
        [Description("Operation did not complete because the DisableWindowsUpdateAccess policy was set.")]
        WU_E_CALL_CANCELLED_BY_POLICY = 0x8024002F,
        [Description("The format of the proxy list was invalid.")]
        WU_E_INVALID_PROXY_SERVER = 0x80240030,
        [Description("The file is in the wrong format.")]
        WU_E_INVALID_FILE = 0x80240031,
        [Description("The search criteria string was invalid.")]
        WU_E_INVALID_CRITERIA = 0x80240032,
        [Description("License terms could not be downloaded.")]
        WU_E_EULA_UNAVAILABLE = 0x80240033,
        [Description("Update failed to download.")]
        WU_E_DOWNLOAD_FAILED = 0x80240034,
        [Description("The update was not processed.")]
        WU_E_UPDATE_NOT_PROCESSED = 0x80240035,
        [Description("The object's current state did not allow the operation.")]
        WU_E_INVALID_OPERATION = 0x80240036,
        [Description("The functionality for the operation is not supported.")]
        WU_E_NOT_SUPPORTED = 0x80240037,
        [Description("The downloaded file has an unexpected content type.")]
        WU_E_WINHTTP_INVALID_FILE = 0x80240038,
        [Description("Agent is asked by server to resync too many times.")]
        WU_E_TOO_MANY_RESYNC = 0x80240039,
        [Description("WUA API method does not run on Server Core installation.")]
        WU_E_NO_SERVER_CORE_SUPPORT = 0x80240040,
        [Description("Service is not available while sysprep is running.")]
        WU_E_SYSPREP_IN_PROGRESS = 0x80240041,
        [Description("The update service is no longer registered with AU.")]
        WU_E_UNKNOWN_SERVICE = 0x80240042,
        [Description("No support for the WUA user interface.")]
        WU_E_NO_UI_SUPPORT = 0x80240043,
        [Description("Only administrators can perform this operation on per-computer updates.")]
        WU_E_PER_MACHINE_UPDATE_ACCESS_DENIED = 0x80240044,
        [Description("A search was attempted with a scope that is not currently supported for this type of search.")]
        WU_E_UNSUPPORTED_SEARCHSCOPE = 0x80240045,
        [Description("The URL does not point to a file.")]
        WU_E_BAD_FILE_URL = 0x80240046,
        [Description("The operation requested is not supported.")]
        WU_E_NOTSUPPORTED = 0x80240047,
        [Description("The featured update notification info returned by the server is invalid.")]
        WU_E_INVALID_NOTIFICATION_INFO = 0x80240048,
        [Description("The data is out of range.")]
        WU_E_OUTOFRANGE = 0x80240049,
        [Description("WUA operations are not available while operating system setup is running.")]
        WU_E_SETUP_IN_PROGRESS = 0x8024004A,
        [Description("An operation failed due to reasons not covered by another error code.")]
        WU_E_UNEXPECTED = 0x80240FFF,
        [Description("Search may have missed some updates because the Windows Installer is less than version 3.1.")]
        WU_E_MSI_WRONG_VERSION = 0x80241001,
        [Description("Search may have missed some updates because the Windows Installer is not configured.")]
        WU_E_MSI_NOT_CONFIGURED = 0x80241002,
        [Description("Search may have missed some updates because policy has disabled Windows Installer patching.")]
        WU_E_MSP_DISABLED = 0x80241003,
        [Description("An update could not be applied because the application is installed per-user.")]
        WU_E_MSI_WRONG_APP_CONTEXT = 0x80241004,
        [Description("Search may have missed some updates because there was a failure of the Windows Installer.")]
        WU_E_MSP_UNEXPECTED = 0x80241FFF,
        [Description("A request for a remote update handler could not be completed because no remote process is available.")]
        WU_E_UH_REMOTEUNAVAILABLE = 0x80242000,
        [Description("A request for a remote update handler could not be completed because the handler is local only.")]
        WU_E_UH_LOCALONLY = 0x80242001,
        [Description("A request for an update handler could not be completed because the handler could not be recognized.")]
        WU_E_UH_UNKNOWNHANDLER = 0x80242002,
        [Description("A remote update handler could not be created because one already exists.")]
        WU_E_UH_REMOTEALREADYACTIVE = 0x80242003,
        [Description("A request for the handler to install (uninstall) an update could not be completed because the update does not support install (uninstall).")]
        WU_E_UH_DOESNOTSUPPORTACTION = 0x80242004,
        [Description("An operation did not complete because the wrong handler was specified.")]
        WU_E_UH_WRONGHANDLER = 0x80242005,
        [Description("A handler operation could not be completed because the update contains invalid metadata.")]
        WU_E_UH_INVALIDMETADATA = 0x80242006,
        [Description("An operation could not be completed because the installer exceeded the time limit.")]
        WU_E_UH_INSTALLERHUNG = 0x80242007,
        [Description("An operation being done by the update handler was cancelled.")]
        WU_E_UH_OPERATIONCANCELLED = 0x80242008,
        [Description("An operation could not be completed because the handler-specific metadata is invalid.")]
        WU_E_UH_BADHANDLERXML = 0x80242009,
        [Description("A request to the handler to install an update could not be completed because the update requires user input.")]
        WU_E_UH_CANREQUIREINPUT = 0x8024200A,
        [Description("The installer failed to install (uninstall) one or more updates.")]
        WU_E_UH_INSTALLERFAILURE = 0x8024200B,
        [Description("The update handler should download self-contained content rather than delta-compressed content for the update.")]
        WU_E_UH_FALLBACKTOSELFCONTAINED = 0x8024200C,
        [Description("The update handler did not install the update because it needs to be downloaded again.")]
        WU_E_UH_NEEDANOTHERDOWNLOAD = 0x8024200D,
        [Description("The update handler failed to send notification of the status of the install (uninstall) operation.")]
        WU_E_UH_NOTIFYFAILURE = 0x8024200E,
        [Description("The file names contained in the update metadata and in the update package are inconsistent.")]
        WU_E_UH_INCONSISTENT_FILE_NAMES = 0x8024200F,
        [Description("The update handler failed to fall back to the self-contained content.")]
        WU_E_UH_FALLBACKERROR = 0x80242010,
        [Description("The update handler has exceeded the maximum number of download requests.")]
        WU_E_UH_TOOMANYDOWNLOADREQUESTS = 0x80242011,
        [Description("The update handler has received an unexpected response from CBS.")]
        WU_E_UH_UNEXPECTEDCBSRESPONSE = 0x80242012,
        [Description("The update metadata contains an invalid CBS package identifier.")]
        WU_E_UH_BADCBSPACKAGEID = 0x80242013,
        [Description("he post-reboot operation for the update is still in progress.")]
        WU_E_UH_POSTREBOOTSTILLPENDING = 0x80242014,
        [Description("The result of the post-reboot operation for the update could not be determined.")]
        WU_E_UH_POSTREBOOTRESULTUNKNOWN = 0x80242015,
        [Description("The state of the update after its post-reboot operation has completed is unexpected.")]
        WU_E_UH_POSTREBOOTUNEXPECTEDSTATE = 0x80242016,
        [Description("The operating system servicing stack must be updated before this update is downloaded or installed.")]
        WU_E_UH_NEW_SERVICING_STACK_REQUIRED = 0x80242017,
        [Description("An update handler error not covered by another WU_E_UH_* code.")]
        WU_E_UH_UNEXPECTED = 0x80242FFF,
        [Description("The results of download and installation could not be read from the registry due to an unrecognized data format version.")]
        WU_E_INSTALLATION_RESULTS_UNKNOWN_VERSION = 0x80243001,
        [Description("The results of download and installation could not be read from the registry due to an invalid data format.")]
        WU_E_INSTALLATION_RESULTS_INVALID_DATA = 0x80243002,
        [Description("The results of download and installation are not available; the operation may have failed to start.")]
        WU_E_INSTALLATION_RESULTS_NOT_FOUND = 0x80243003,
        [Description("A failure occurred when trying to create an icon in the taskbar notification area.")]
        WU_E_TRAYICON_FAILURE = 0x80243004,
        [Description("Unable to show UI when in non-UI mode; WU client UI modules may not be installed.")]
        WU_E_NON_UI_MODE = 0x80243FFD,
        [Description("Unsupported version of WU client UI exported functions.")]
        WU_E_WUCLTUI_UNSUPPORTED_VERSION = 0x80243FFE,
        [Description("There was a user interface error not covered by another WU_E_AUCLIENT_* error code.")]
        WU_E_AUCLIENT_UNEXPECTED = 0x80243FFF,
        [Description("WU_E_PT_SOAPCLIENT_* error codes map to the SOAPCLIENT_ERROR enum of the ATL Server Library.")]
        WU_E_PT_SOAPCLIENT_BASE = 0x80244000,
        [Description("SOAPCLIENT_INITIALIZE_ERROR - initialization of the SOAP client failed, possibly because of an MSXML installation failure.")]
        WU_E_PT_SOAPCLIENT_INITIALIZE = 0x80244001,
        [Description("SOAPCLIENT_OUTOFMEMORY - SOAP client failed because it ran out of memory.")]
        WU_E_PT_SOAPCLIENT_OUTOFMEMORY = 0x80244002,
        [Description("SOAPCLIENT_GENERATE_ERROR - SOAP client failed to generate the request.")]
        WU_E_PT_SOAPCLIENT_GENERATE = 0x80244003,
        [Description("SOAPCLIENT_CONNECT_ERROR - SOAP client failed to connect to the server.")]
        WU_E_PT_SOAPCLIENT_CONNECT = 0x80244004,
        [Description("SOAPCLIENT_SEND_ERROR - SOAP client failed to send a message for reasons of WU_E_WINHTTP_* error codes.")]
        WU_E_PT_SOAPCLIENT_SEND = 0x80244005,
        [Description("SOAPCLIENT_SERVER_ERROR - SOAP client failed because there was a server error.")]
        WU_E_PT_SOAPCLIENT_SERVER = 0x80244006,
        [Description("SOAPCLIENT_SOAPFAULT - SOAP client failed because there was a SOAP fault for reasons of WU_E_PT_SOAP_* error codes.")]
        WU_E_PT_SOAPCLIENT_SOAPFAULT = 0x80244007,
        [Description("SOAPCLIENT_PARSEFAULT_ERROR - SOAP client failed to parse a SOAP fault.")]
        WU_E_PT_SOAPCLIENT_PARSEFAULT = 0x80244008,
        [Description("SOAPCLIENT_READ_ERROR - SOAP client failed while reading the response from the server.")]
        WU_E_PT_SOAPCLIENT_READ = 0x80244009,
        [Description("SOAPCLIENT_PARSE_ERROR - SOAP client failed to parse the response from the server.")]
        WU_E_PT_SOAPCLIENT_PARSE = 0x8024400A,
        [Description("SOAP_E_VERSION_MISMATCH - SOAP client found an unrecognizable namespace for the SOAP envelope.")]
        WU_E_PT_SOAP_VERSION = 0x8024400B,
        [Description("SOAP_E_MUST_UNDERSTAND - SOAP client was unable to understand a header.")]
        WU_E_PT_SOAP_MUST_UNDERSTAND = 0x8024400C,
        [Description("SOAP_E_CLIENT - SOAP client found the message was malformed; fix before resending.")]
        WU_E_PT_SOAP_CLIENT = 0x8024400D,
        [Description("SOAP_E_SERVER - The SOAP message could not be processed due to a server error; resend later.")]
        WU_E_PT_SOAP_SERVER = 0x8024400E,
        [Description("There was an unspecified Windows Management Instrumentation (WMI) error.")]
        WU_E_PT_WMI_ERROR = 0x8024400F,
        [Description("The number of round trips to the server exceeded the maximum limit.")]
        WU_E_PT_EXCEEDED_MAX_SERVER_TRIPS = 0x80244010,
        [Description("WUServer policy value is missing in the registry.")]
        WU_E_PT_SUS_SERVER_NOT_SET = 0x80244011,
        [Description("Initialization failed because the object was already initialized.")]
        WU_E_PT_DOUBLE_INITIALIZATION = 0x80244012,
        [Description("The computer name could not be determined.")]
        WU_E_PT_INVALID_COMPUTER_NAME = 0x80244013,
        [Description("The reply from the server indicates that the server was changed or the cookie was invalid; refresh the state of the internal cache and retry.")]
        WU_E_PT_REFRESH_CACHE_REQUIRED = 0x80244015,
        [Description("HTTP 400 - the server could not process the request due to invalid syntax.")]
        WU_E_PT_HTTP_STATUS_BAD_REQUEST = 0x80244016,
        [Description("HTTP 401 - the requested resource requires user authentication.")]
        WU_E_PT_HTTP_STATUS_DENIED = 0x80244017,
        [Description("HTTP 403 - server understood the request, but declined to fulfill it.")]
        WU_E_PT_HTTP_STATUS_FORBIDDEN = 0x80244018,
        [Description("HTTP 404 - the server cannot find the requested URI (Uniform Resource Identifier).")]
        WU_E_PT_HTTP_STATUS_NOT_FOUND = 0x80244019,
        [Description("HTTP 405 - the HTTP method is not allowed.")]
        WU_E_PT_HTTP_STATUS_BAD_METHOD = 0x8024401A,
        [Description("HTTP 407 - proxy authentication is required.")]
        WU_E_PT_HTTP_STATUS_PROXY_AUTH_REQ = 0x8024401B,
        [Description("HTTP 408 - the server timed out waiting for the request.")]
        WU_E_PT_HTTP_STATUS_REQUEST_TIMEOUT = 0x8024401C,
        [Description("HTTP 409 - the request was not completed due to a conflict with the current state of the resource.")]
        WU_E_PT_HTTP_STATUS_CONFLICT = 0x8024401D,
        [Description("HTTP 410 - requested resource is no longer available at the server.")]
        WU_E_PT_HTTP_STATUS_GONE = 0x8024401E,
        [Description("HTTP 500 - an error internal to the server prevented fulfilling the request.")]
        WU_E_PT_HTTP_STATUS_SERVER_ERROR = 0x8024401F,
        [Description("HTTP 501 - server does not support the functionality required to fulfill the request.")]
        WU_E_PT_HTTP_STATUS_NOT_SUPPORTED = 0x80244020,
        [Description("HTTP 502 - the server, while acting as a gateway or proxy, received an invalid response from the upstream server it accessed in attempting to fulfill the request.")]
        WU_E_PT_HTTP_STATUS_BAD_GATEWAY = 0x80244021,
        [Description("HTTP 503 - the service is temporarily overloaded.")]
        WU_E_PT_HTTP_STATUS_SERVICE_UNAVAIL = 0x80244022,
        [Description("HTTP 504 - the request was timed out waiting for a gateway.")]
        WU_E_PT_HTTP_STATUS_GATEWAY_TIMEOUT = 0x80244023,
        [Description("HTTP 505 - the server does not support the HTTP protocol version used for the request.")]
        WU_E_PT_HTTP_STATUS_VERSION_NOT_SUP = 0x80244024,
        [Description("Operation failed due to a changed file location; refresh internal state and resend.")]
        WU_E_PT_FILE_LOCATIONS_CHANGED = 0x80244025,
        [Description("Operation failed because Windows Update Agent does not support registration with a non-WSUS server.")]
        WU_E_PT_REGISTRATION_NOT_SUPPORTED = 0x80244026,
        [Description("The server returned an empty authentication information list.")]
        WU_E_PT_NO_AUTH_PLUGINS_REQUESTED = 0x80244027,
        [Description("Windows Update Agent was unable to create any valid authentication cookies.")]
        WU_E_PT_NO_AUTH_COOKIES_CREATED = 0x80244028,
        [Description("A configuration property value was wrong.")]
        WU_E_PT_INVALID_CONFIG_PROP = 0x80244029,
        [Description("A configuration property value was missing.")]
        WU_E_PT_CONFIG_PROP_MISSING = 0x8024402A,
        [Description("The HTTP request could not be completed and the reason did not correspond to any of the WU_E_PT_HTTP_* error codes.")]
        WU_E_PT_HTTP_STATUS_NOT_MAPPED = 0x8024402B,
        [Description("ERROR_WINHTTP_NAME_NOT_RESOLVED - the proxy server or target server name cannot be resolved.")]
        WU_E_PT_WINHTTP_NAME_NOT_RESOLVED = 0x8024402C,
        [Description("External cab file processing completed with some errors.")]
        WU_E_PT_ECP_SUCCEEDED_WITH_ERRORS = 0x8024402F,
        [Description("The external cab processor initialization did not complete.")]
        WU_E_PT_ECP_INIT_FAILED = 0x80244030,
        [Description("The format of a metadata file was invalid.")]
        WU_E_PT_ECP_INVALID_FILE_FORMAT = 0x80244031,
        [Description("External cab processor found invalid metadata.")]
        WU_E_PT_ECP_INVALID_METADATA = 0x80244032,
        [Description("The file digest could not be extracted from an external cab file.")]
        WU_E_PT_ECP_FAILURE_TO_EXTRACT_DIGEST = 0x80244033,
        [Description("An external cab file could not be decompressed.")]
        WU_E_PT_ECP_FAILURE_TO_DECOMPRESS_CAB_FILE = 0x80244034,
        [Description("External cab processor was unable to get file locations.")]
        WU_E_PT_ECP_FILE_LOCATION_ERROR = 0x80244035,
        [Description("A communication error not covered by another WU_E_PT_* error code")]
        WU_E_PT_UNEXPECTED = 0x80244FFF,
        [Description("The redirector XML document could not be loaded into the DOM class.")]
        WU_E_REDIRECTOR_LOAD_XML = 0x80245001,
        [Description("The redirector XML document is missing some required information.")]
        WU_E_REDIRECTOR_S_FALSE = 0x80245002,
        [Description("The redirector ID in the downloaded redirector cab is less than in the cached cab.")]
        WU_E_REDIRECTOR_ID_SMALLER = 0x80245003,
        [Description("Windows Update Agent failed to download a redirector cabinet file with a new redirector ID value from the server during the recovery.")]
        WU_E_PT_SAME_REDIR_ID = 0x8024502D,
        [Description("A redirector recovery action did not complete because the server is managed.")]
        WU_E_PT_NO_MANAGED_RECOVER = 0x8024502E,
        [Description("The redirector failed for reasons not covered by another WU_E_REDIRECTOR_* error code.")]
        WU_E_REDIRECTOR_UNEXPECTED = 0x80245FFF,
        [Description("A download manager operation could not be completed because the requested file does not have a URL.")]
        WU_E_DM_URLNOTAVAILABLE = 0x80246001,
        [Description("A download manager operation could not be completed because the file digest was not recognized.")]
        WU_E_DM_INCORRECTFILEHASH = 0x80246002,
        [Description("A download manager operation could not be completed because the file metadata requested an unrecognized hash algorithm.")]
        WU_E_DM_UNKNOWNALGORITHM = 0x80246003,
        [Description("An operation could not be completed because a download request is required from the download handler.")]
        WU_E_DM_NEEDDOWNLOADREQUEST = 0x80246004,
        [Description("A download manager operation could not be completed because the network connection was unavailable.")]
        WU_E_DM_NONETWORK = 0x80246005,
        [Description("A download manager operation could not be completed because the version of Background Intelligent Transfer Service (BITS) is incompatible.")]
        WU_E_DM_WRONGBITSVERSION = 0x80246006,
        [Description("The update has not been downloaded.")]
        WU_E_DM_NOTDOWNLOADED = 0x80246007,
        [Description("A download manager operation failed because the download manager was unable to connect the Background Intelligent Transfer Service (BITS).")]
        WU_E_DM_FAILTOCONNECTTOBITS = 0x80246008,
        [Description("A download manager operation failed because there was an unspecified Background Intelligent Transfer Service (BITS) transfer error.")]
        WU_E_DM_BITSTRANSFERERROR = 0x80246009,
        [Description("A download must be restarted because the location of the source of the download has changed.")]
        WU_E_DM_DOWNLOADLOCATIONCHANGED = 0x8024600a,
        [Description("A download must be restarted because the update content changed in a new revision.")]
        WU_E_DM_CONTENTCHANGED = 0x8024600B,
        [Description("There was a download manager error not covered by another WU_E_DM_* error code.")]
        WU_E_DM_UNEXPECTED = 0x80246FFF,
        [Description("An operation could not be completed because the scan package was invalid.")]
        WU_E_OL_INVALID_SCANFILE = 0x80247001,
        [Description("An operation could not be completed because the scan package requires a greater version of the Windows Update Agent.")]
        WU_E_OL_NEWCLIENT_REQUIRED = 0x80247002,
        [Description("Search using the scan package failed.")]
        WU_E_OL_UNEXPECTED = 0x80247FFF,
        [Description("An operation failed because Windows Update Agent is shutting down.")]
        WU_E_DS_SHUTDOWN = 0x80248000,
        [Description("An operation failed because the data store was in use.")]
        WU_E_DS_INUSE = 0x80248001,
        [Description("The current and expected states of the data store do not match.")]
        WU_E_DS_INVALID = 0x80248002,
        [Description("The data store is missing a table.")]
        WU_E_DS_TABLEMISSING = 0x80248003,
        [Description("The data store contains a table with unexpected columns.")]
        WU_E_DS_TABLEINCORRECT = 0x80248004,
        [Description("A table could not be opened because the table is not in the data store.")]
        WU_E_DS_INVALIDTABLENAME = 0x80248005,
        [Description("The current and expected versions of the data store do not match.")]
        WU_E_DS_BADVERSION = 0x80248006,
        [Description("The information requested is not in the data store.")]
        WU_E_DS_NODATA = 0x80248007,
        [Description("The data store is missing required information or has a NULL in a table column that requires a non-null value.")]
        WU_E_DS_MISSINGDATA = 0x80248008,
        [Description("The data store is missing required information or has a reference to missing license terms, file, localized property or linked row.")]
        WU_E_DS_MISSINGREF = 0x80248009,
        [Description("The update was not processed because its update handler could not be recognized.")]
        WU_E_DS_UNKNOWNHANDLER = 0x8024800A,
        [Description("The update was not deleted because it is still referenced by one or more services.")]
        WU_E_DS_CANTDELETE = 0x8024800B,
        [Description("The data store section could not be locked within the allotted time.")]
        WU_E_DS_LOCKTIMEOUTEXPIRED = 0x8024800C,
        [Description("The category was not added because it contains no parent categories and is not a top-level category itself.")]
        WU_E_DS_NOCATEGORIES = 0x8024800D,
        [Description("The row was not added because an existing row has the same primary key.")]
        WU_E_DS_ROWEXISTS = 0x8024800E,
        [Description("The data store could not be initialized because it was locked by another process.")]
        WU_E_DS_STOREFILELOCKED = 0x8024800F,
        [Description("The data store is not allowed to be registered with COM in the current process.")]
        WU_E_DS_CANNOTREGISTER = 0x80248010,
        [Description("Could not create a data store object in another process.")]
        WU_E_DS_UNABLETOSTART = 0x80248011,
        [Description("The server sent the same update to the client with two different revision IDs.")]
        WU_E_DS_DUPLICATEUPDATEID = 0x80248013,
        [Description("An operation did not complete because the service is not in the data store.")]
        WU_E_DS_UNKNOWNSERVICE = 0x80248014,
        [Description("An operation did not complete because the registration of the service has expired.")]
        WU_E_DS_SERVICEEXPIRED = 0x80248015,
        [Description("A request to hide an update was declined because it is a mandatory update or because it was deployed with a deadline.")]
        WU_E_DS_DECLINENOTALLOWED = 0x80248016,
        [Description("A table was not closed because it is not associated with the session.")]
        WU_E_DS_TABLESESSIONMISMATCH = 0x80248017,
        [Description("A table was not closed because it is not associated with the session.")]
        WU_E_DS_SESSIONLOCKMISMATCH = 0x80248018,
        [Description("A request to remove the Windows Update service or to unregister it with Automatic Updates was declined because it is a built-in service and/or Automatic Updates cannot fall back to another service.")]
        WU_E_DS_NEEDWINDOWSSERVICE = 0x80248019,
        [Description("A request was declined because the operation is not allowed.")]
        WU_E_DS_INVALIDOPERATION = 0x8024801A,
        [Description("The schema of the current data store and the schema of a table in a backup XML document do not match.")]
        WU_E_DS_SCHEMAMISMATCH = 0x8024801B,
        [Description("The data store requires a session reset; release the session and retry with a new session.")]
        WU_E_DS_RESETREQUIRED = 0x8024801C,
        [Description("A data store operation did not complete because it was requested with an impersonated identity.")]
        WU_E_DS_IMPERSONATED = 0x8024801D,
        [Description("A data store error not covered by another WU_E_DS_* code.")]
        WU_E_DS_UNEXPECTED = 0x80248FFF,
        [Description("Parsing of the rule file failed.")]
        WU_E_INVENTORY_PARSEFAILED = 0x80249001,
        [Description("Failed to get the requested inventory type from the server.")]
        WU_E_INVENTORY_GET_INVENTORY_TYPE_FAILED = 0x80249002,
        [Description("Failed to upload inventory result to the server.")]
        WU_E_INVENTORY_RESULT_UPLOAD_FAILED = 0x80249003,
        [Description("There was an inventory error not covered by another error code.")]
        WU_E_INVENTORY_UNEXPECTED = 0x80249004,
        [Description("A WMI error occurred when enumerating the instances for a particular class.")]
        WU_E_INVENTORY_WMI_ERROR = 0x80249005,
        [Description("Automatic Updates was unable to service incoming requests.")]
        WU_E_AU_NOSERVICE = 0x8024A000,
        [Description("The old version of the Automatic Updates client has stopped because the WSUS server has been upgraded.")]
        WU_E_AU_NONLEGACYSERVER = 0x8024A002,
        [Description("The old version of the Automatic Updates client was disabled.")]
        WU_E_AU_LEGACYCLIENTDISABLED = 0x8024A003,
        [Description("Automatic Updates was unable to process incoming requests because it was paused.")]
        WU_E_AU_PAUSED = 0x8024A004,
        [Description("No unmanaged service is registered with AU.")]
        WU_E_AU_NO_REGISTERED_SERVICE = 0x8024A005,
        [Description("An Automatic Updates error not covered by another WU_E_AU * code.")]
        WU_E_AU_UNEXPECTED = 0x8024AFFF,
        [Description("A driver was skipped.")]
        WU_E_DRV_PRUNED = 0x8024C001,
        [Description("A property for the driver could not be found. It may not conform with required specifications.")]
        WU_E_DRV_NOPROP_OR_LEGACY = 0x8024C002,
        [Description("The registry type read for the driver does not match the expected type.")]
        WU_E_DRV_REG_MISMATCH = 0x8024C003,
        [Description("The driver update is missing metadata.")]
        WU_E_DRV_NO_METADATA = 0x8024C004,
        [Description("The driver update is missing a required attribute.")]
        WU_E_DRV_MISSING_ATTRIBUTE = 0x8024C005,
        [Description("Driver synchronization failed.")]
        WU_E_DRV_SYNC_FAILED = 0x8024C006,
        [Description("Information required for the synchronization of applicable printers is missing.")]
        WU_E_DRV_NO_PRINTER_CONTENT = 0x8024C007,
        [Description("A driver error not covered by another WU_E_DRV_* code.")]
        WU_E_DRV_UNEXPECTED = 0x8024CFFF,
        [Description("Windows Update Agent could not be updated because an INF file contains invalid information.")]
        WU_E_SETUP_INVALID_INFDATA = 0x8024D001,
        [Description("Windows Update Agent could not be updated because the wuident.cab file contains invalid information.")]
        WU_E_SETUP_INVALID_IDENTDATA = 0x8024D002,
        [Description("Windows Update Agent could not be updated because of an internal error that caused setup initialization to be performed twice.")]
        WU_E_SETUP_ALREADY_INITIALIZED = 0x8024D003,
        [Description("Windows Update Agent could not be updated because setup initialization never completed successfully.")]
        WU_E_SETUP_NOT_INITIALIZED = 0x8024D004,
        [Description("Windows Update Agent could not be updated because the versions specified in the INF do not match the actual source file versions.")]
        WU_E_SETUP_SOURCE_VERSION_MISMATCH = 0x8024D005,
        [Description("Windows Update Agent could not be updated because a WUA file on the target system is newer than the corresponding source file.")]
        WU_E_SETUP_TARGET_VERSION_GREATER = 0x8024D006,
        [Description("Windows Update Agent could not be updated because regsvr32.exe returned an error.")]
        WU_E_SETUP_REGISTRATION_FAILED = 0x8024D007,
        [Description("An update to the Windows Update Agent was skipped because previous attempts to update have failed.")]
        WU_E_SELFUPDATE_SKIP_ON_FAILURE = 0x8024D008,
        [Description("An update to the Windows Update Agent was skipped due to a directive in the wuident.cab file.")]
        WU_E_SETUP_SKIP_UPDATE = 0x8024D009,
        [Description("Windows Update Agent could not be updated because the current system configuration is not supported.")]
        WU_E_SETUP_UNSUPPORTED_CONFIGURATION = 0x8024D00A,
        [Description("Windows Update Agent could not be updated because the system is configured to block the update.")]
        WU_E_SETUP_BLOCKED_CONFIGURATION = 0x8024D00B,
        [Description("Windows Update Agent could not be updated because a restart of the system is required.")]
        WU_E_SETUP_REBOOT_TO_FIX = 0x8024D00C,
        [Description("Windows Update Agent setup is already running.")]
        WU_E_SETUP_ALREADYRUNNING = 0x8024D00D,
        [Description("Windows Update Agent setup package requires a reboot to complete installation.")]
        WU_E_SETUP_REBOOTREQUIRED = 0x8024D00E,
        [Description("Windows Update Agent could not be updated because the setup handler failed during execution.")]
        WU_E_SETUP_HANDLER_EXEC_FAILURE = 0x8024D00F,
        [Description("Windows Update Agent could not be updated because the registry contains invalid information.")]
        WU_E_SETUP_INVALID_REGISTRY_DATA = 0x8024D010,
        [Description("Windows Update Agent must be updated before search can continue.")]
        WU_E_SELFUPDATE_REQUIRED = 0x8024D011,
        [Description("Windows Update Agent must be updated before search can continue. An administrator is required to perform the operation.")]
        WU_E_SELFUPDATE_REQUIRED_ADMIN = 0x8024D012,
        [Description("Windows Update Agent could not be updated because the server does not contain update information for this version.")]
        WU_E_SETUP_WRONG_SERVER_VERSION = 0x8024D013,
        [Description("Windows Update Agent could not be updated because of an error not covered by another WU_E_SETUP_* error code.")]
        WU_E_SETUP_UNEXPECTED = 0x8024DFFF,
        [Description("An expression evaluator operation could not be completed because an expression was unrecognized.")]
        WU_E_EE_UNKNOWN_EXPRESSION = 0x8024E001,
        [Description("An expression evaluator operation could not be completed because an expression was invalid.")]
        WU_E_EE_INVALID_EXPRESSION = 0x8024E002,
        [Description("An expression evaluator operation could not be completed because an expression contains an incorrect number of metadata nodes.")]
        WU_E_EE_MISSING_METADATA = 0x8024E003,
        [Description("An expression evaluator operation could not be completed because the version of the serialized expression data is invalid.")]
        WU_E_EE_INVALID_VERSION = 0x8024E004,
        [Description("The expression evaluator could not be initialized.")]
        WU_E_EE_NOT_INITIALIZED = 0x8024E005,
        [Description("An expression evaluator operation could not be completed because there was an invalid attribute.")]
        WU_E_EE_INVALID_ATTRIBUTEDATA = 0x8024E006,
        [Description("An expression evaluator operation could not be completed because the cluster state of the computer could not be determined.")]
        WU_E_EE_CLUSTER_ERROR = 0x8024E007,
        [Description("There was an expression evaluator error not covered by another WU_E_EE_* error code.")]
        WU_E_EE_UNEXPECTED = 0x8024EFFF,
        [Description("The event cache file was defective.")]
        WU_E_REPORTER_EVENTCACHECORRUPT = 0x8024F001,
        [Description("The XML in the event namespace descriptor could not be parsed.")]
        WU_E_REPORTER_EVENTNAMESPACEPARSEFAILED = 0x8024F002,
        [Description("The XML in the event namespace descriptor could not be parsed.")]
        WU_E_INVALID_EVENT = 0x8024F003,
        [Description("The server rejected an event because the server was too busy.")]
        WU_E_SERVER_BUSY = 0x8024F004,
        [Description("There was a reporter error not covered by another error code.")]
        WU_E_REPORTER_UNEXPECTED = 0x8024FFFF,
    }
    public static class ResultCodeExtension
    {
        public static string GetDescription(this HResult HResult)
        {
            return HResult.GetType().GetField(HResult.ToString())?.GetCustomAttribute<DescriptionAttribute>()?.Description;
        }
    }
}
