/*<FILE_LICENSE>
* NFX (.NET Framework Extension) Unistack Library
* Copyright 2003-2018 Agnicore Inc. portions ITAdapter Corp. Inc.
*
* Licensed under the Apache License, Version 2.0 (the "License");
* you may not use this file except in compliance with the License.
* You may obtain a copy of the License at
*
* http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an "AS IS" BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
</FILE_LICENSE>*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NFX.Web
{
  public static class StringConsts
  {

    public const string CONTRACT_NS = "http://itadapter.com/nfx/web";


    public const string WEB_LOG_TOPIC = "NFX.Web";

    public const string MAILER_LOG_TOPIC = "Mailer";


    public const string NFX_WEB_APP_CONFIGURATION_FILE = "NFXWebApp.configuration";

    public const string GUID_KEY = "GUID";

    public const string NAME_KEY = "NAME";

    public const string STRIP_KEY = "STRIP";

    public const string NO_ROUTE_CONTEXT = "<no route context>";

    public const string UNKNOWN = "<unknown>";



    public const string ARGUMENT_ERROR =
            "Argument error: ";


    public const string OPERATION_NOT_SUPPORTED_ERROR =
            "Operation not supported: ";


    public const string CONTEXT_NOT_AVAILABLE_ERROR =
          "Requested context is not available: ";

    public const string APP_INIT_CONFIG_ERROR = "Application init configuration error: ";

    public const string APP_INSTANCE_ALREADY_CREATED_ERROR =
         "Application instance has already been created";

    public const string APP_INSTANCE_NULL_ERROR =
         "Application instance has not been created";


    public const string APP_LOG_INIT_ERROR =
          "Application log initApplication error: ";

    public const string APP_DATA_STORE_INIT_ERROR =
          "Application data store initApplication error: ";

    public const string APP_INSTRUMENTATION_INIT_ERROR =
          "Application instrumentation initApplication error: ";

    public const string APP_OBJECT_STORE_INIT_ERROR =
          "Application object store initApplication error: ";

    public const string APP_FORMS_FACTORY_INIT_ERROR =
          "Application forms factory initApplication error: ";

    public const string APP_SESSION_STRATEGY_INIT_ERROR =
          "Application session strategy initApplication error: ";

    public const string WEB_HANDLER_TOPIC =
          "WebHandler";

    public const string NO_RECORD_IN_VOLATILE_STORE_ERROR =
            "Volatile store returned no record instance. It may have expired " ;

    public const string DONT_KNOW_ACTION_ERROR =
        "Dont know how to handle site action: ";

    public const string NOT_FOUND_ERROR =
        "404 Not Found: ";



    public const string BASE_HANDLER_EXCEPTION_ERROR = "Error exception leaked into BaseHandler: ";

    public const string MODEL_ROUTE_HANDLER_ERROR = "Error in ModelRouteHandler: ";
    public const string MODEL_NOT_FOUND_ERROR = "ModelHandler could not find record to operate on. GUID: '{0}' \n Error: \n\n {1}";
    public const string MODEL_FIELD_NOT_FOUND_ERROR = "ModelHandler could not find a record field to operate on. Field Name: '{0}'";
    public const string MODEL_CLIENT_REQUEST_READ_ERROR = "ClientRequest could not be read: ";
    public const string MODEL_PROTOCOL_ERROR = "ModelHandler protocol error: ";

    public const string MODEL_METHOD_NOT_FOUND_ERROR = "ModelHandler could not find a record callable method to invoke. Method Name: '{0}'";


    public const string SCRIPT_ROUTE_HANDLER_ERROR = "Error in ScriptRouteHandler: ";
    public const string SCRIPT_READ_ERROR = "Script cound not be read, check name: ";
    public const string SCRIPT_NAME_MISSING_ERROR = "Script name missing";


    public const string TYPELOOKUP_404_LOG_MSG = "Type lookup failed. User IP='{0}' FilePath='{1}' PathInfo='{2}'";




    public const string CONTROLLER_SESSION_MISMATCH_WARNING = "Stateful controller mismatched session id. Controller: '{0}', Session: '{1}'";

    public const string CONTROLLER_ACTION_METHOD_NOT_FOUND_ERROR = "No suitable action method found. Controller/Action: {0}/{1}";


    public const string WEB_REQUEST_ERROR = "Error while performing WebRequest: ";

    public const string FS_SVN_PARAMS_SERVER_URL_ERROR =
          "SVN connection parameters need to specify non-blank ServerURL";

    public const string FS_S3_PARAMS_SERVER_URL_ERROR =
          "S3 connection parameters need to specify non-blank Bucket and Region";

    public const string GEO_LOOKUP_SVC_RESOLUTION_ERROR =
          "GEO lookup service does not support '{0}' resolution";

    public const string GEO_LOOKUP_SVC_PATH_ERROR =
          "GEO lookup service is pointed at '{0}' path which does not exist";

    public const string GEO_LOOKUP_SVC_DATA_FILE_ERROR =
          "GEO lookup service needs data file '{0}' which was not found";

    public const string SOCIAL_NETWORK_DUPLICATE_NAME = "Can not have social network instance of type '{0}' with the name '{1}' as this name is already registered. ";

    public const string PAYMENT_CURRENCY_CONVERSION_MAPPING_ERROR = "Currency mapping for '{0}' -> '{1}' is not found by provider '{2}' or rate attr missing";

    public const string PAYMENT_CURRENCY_NOT_SUPPORTED_ERROR = "Currency '{0}' is not supported by provider '{1}' or currency attr missing";

    public const string PAYMENT_SYSTEM_HOST_NULL_ERROR = "Payment system host is not set";
    public const string PAYMENT_UNKNOWN_ACCOUNT_ERROR = "Unknown account '{0}'";
    public const string PAYMENT_SYSTEM_DUPLICATE_NAME_ERROR = "Can not have payment system instance of type '{0}' with the name '{1}' as this name is already registered. ";
    public const string PAYMENT_INVALID_CARD_NUMBER_ERROR = "Invalid card number '{0:0000 0000 0000 0000}'. ";
    public const string PAYMENT_INVALID_EXPIRATION_DATE_ERROR = "Invalid card expiration year '{0}' or month '{1}'. ";
    public const string PAYMENT_INVALID_CVC_ERROR = "Invalid card CVC '{0}'. ";
    public const string PAYMENT_INVALID_ADDR_ERROR = "Invalid card address. ";
    public const string PAYMENT_INVALID_CUSTOMER_ERROR = "Customer name '{0}' couldn't be null or empty. ";
    public const string PAYMENT_CANNOT_VOID_ERROR = "Payment failed to be voided";
    public const string PAYMENT_CANNOT_CHARGE_PAYMENT_ERROR = "Payment failed to be charged. ";
    public const string PAYMENT_CANNOT_CAPTURE_CAPTURED_PAYMENT_ERROR = "Captured payment cannot be captured again. ";
    public const string PAYMENT_CANNOT_CREATE_RECIPIENT_ERROR = "Recipient couldn't be created. ";
    public const string PAYMENT_CANNOT_TRANSFER_ERROR = "Transfer failed. ";
    public const string PAYMENT_INVALID_PAYSYSTEM_ERROR = "Payment was created in other pay system. ";
    public const string PAYMENT_CAPTURE_CURRENCY_MUST_MATCH_CHARGE_ERROR = "Capture currency must be the same as original charge currency.";
    public const string PAYMENT_REFUND_CANNOT_BE_REFUNDED_ERROR = "Transaction '{0}' couldn't be refunded. It could have wrong type, not captured or already completely refunded. ";
    public const string PAYMENT_REFUND_CURRENCY_MUST_MATCH_CHARGE_ERROR = "Refund currency must be the same as original charge currency. ";
    public const string PAYMENT_REFUND_EXCEEDS_CHARGE_ERROR = "Required refund value '{0}' in sum with previously refunded value '{1}' exceeds original charge '{2}'. ";

    public const string PAYMENT_STRIPE_400_ERROR = "400 Bad Request - Often missing a required parameter. ";
    public const string PAYMENT_STRIPE_401_ERROR = "401 Unauthorized - No valid API key provided. ";
    public const string PAYMENT_STRIPE_402_ERROR = "402 Parameters were valid but request failed. ";
    public const string PAYMENT_STRIPE_404_ERROR = "404 Not Found - The requested item doesn't exist. ";
    public const string PAYMENT_STRIPE_50X_ERROR = "{0} Server error - something went wrong on Stripe's end. ";

    public const string PAYMENT_STRIPE_ERR_MSG_ERROR = "Stripe reported error: \"{0}\". ";

    public const string PAYMENT_PAYPAL_200_STATUSCODE = "Request OK";
    public const string PAYMENT_PAYPAL_201_STATUSCODE = "Resource created";
    public const string PAYMENT_PAYPAL_400_STATUSCODE = "Bad request";
    public const string PAYMENT_PAYPAL_401_STATUSCODE = "Unauthorized request";
    public const string PAYMENT_PAYPAL_402_STATUSCODE = "Failed request";
    public const string PAYMENT_PAYPAL_403_STATUSCODE = "Forbidden";
    public const string PAYMENT_PAYPAL_404_STATUSCODE = "Resource was not found";
    public const string PAYMENT_PAYPAL_405_STATUSCODE = "Method not allowed";
    public const string PAYMENT_PAYPAL_415_STATUSCODE = "Unsupported media type";
    public const string PAYMENT_PAYPAL_422_STATUSCODE = "Unprocessable entity";
    public const string PAYMENT_PAYPAL_429_STATUSCODE = "Too many requests";
    public const string PAYMENT_PAYPAL_50x_STATUSCODE = "PayPal server error";
    public const string PAYMENT_PAYPAL_UNKNOWN_STATUSCODE = "PayPal unknown error";

    public const string PAYPAL_GENERATE_OAUTH_ERROR_MESSAGE = "Error while refreshing OAuth token: {0}";
    public const string PAYPAL_PAYOUTS_CREATE_ERROR_MESSAGE = "Error while create payouts: {0}";
    public const string PAYPAL_PAYOUTS_FETCH_ERROR_MESSAGE = "Error while fetch payouts: {0}";
    public const string PAYPAL_PAYOUT_ITEM_FETCH_ERROR_MESSAGE = "Error while fetch payout item: {0}";
    public const string PAYPAL_PAYOUT_ITEM_CANCEL_ERROR_MESSAGE = "Error while payout item cancellation: {0}";
    public const string PAYPAL_PAYOUT_ERROR = "Critical error while transaction (account: {0}, amount: {1}) processing: {2}";
    public const string PAYPAL_VOID_ERROR_MESSAGE = "Critical error while transaction cancellation: {0}";
    public const string PAYPAL_PAYOUT_NOT_SUCCEEDED_MESSAGE = "Payout was not succeeded. Error: {0}, Message: {1}, Description: {2}";

    public const string SHIPPING_SYSTEM_UNSUPPORTED_ACTION = "Action {0} is not supported by the shipping system";

    public const string SHIPPING_SYSTEM_HOST_NULL_ERROR = "Shipping system host is not set";
    public const string SHIPPING_SYSTEM_DUPLICATE_NAME_ERROR = "Can not have shipping system instance of type '{0}' with the name '{1}' as this name is already registered. ";
    public const string SHIPPO_CREATE_LABEL_MESSAGE = "Perform create label: from {0}, to {1}";
    public const string SHIPPO_CREATE_LABEL_ERROR = "Critical error while create shipping label from {0}, to {1}: {2}";
    public const string SHIPPO_OPERATION_FAILED = "Operation failed";
    public const string SHIPPO_CAN_NOT_MAP_LABEL_FORMAT = "Unknown label format";
    public const string SHIPPO_GET_RATE_ERROR = "Critical error while fetch label rate";
    public const string SHIPPO_TRACK_SHIPMENT_MESSAGE = "Perform track shipment by number '{0}'";
    public const string SHIPPO_TRACK_SHIPMENT_ERROR = "Critical error while tracking shipment '{0}': {1}";
    public const string SHIPPO_VALIDATE_ADDRESS_MESSAGE = "Perform address validation";
    public const string SHIPPO_VALIDATE_ADDRESS_ERROR = "Critical error while validate address: {0}";
    public const string SHIPPO_VALIDATE_ADDRESS_INVALID_ERROR = "The address is invalid: {0}";
    public const string SHIPPO_ESTIMATE_SHIPPING_COST_MESSAGE = "Perform shipping cost estimation: from {0}, to {1}, method '{2}'";
    public const string SHIPPO_ESTIMATE_SHIPPING_COST_ERROR = "Critical error while estimate shipping cost from {0}, to {1}, method '{2}': {3}";

    public const string TAX_CALCULATOR_DUPLICATE_NAME_ERROR = "Can not have tax calculator instance of type '{0}' with the name '{1}' as this name is already registered. ";
    public const string TAX_TAXJAR_TOADDRESS_ISNT_SUPPLIED_ERROR = "Either retailerAddress or wholesellerAddress must be provided. ";
    public const string TAX_CALC_ERROR = "Calculation failed. ";
    public const string TAX_CALC_DIFFERENT_CURRENCIES_ERROR = "Prices and shipping must be represented in the same currency. ";

    public const string MULTIPART_DOUBLE_EOL_ISNT_FOUND_AFTER_HEADER_ERROR = "Multipart: Double \\r\\n isn't found after header.";
    public const string MULTIPART_PARTS_COULDNT_BE_EMPTY_ERROR = "Multipart: Parts couldn't be null or empty.";
    public const string MULTIPART_PART_COULDNT_BE_EMPTY_ERROR = "Multipart: Part couldn't empty.";
    public const string MULTIPART_PART_MUST_BE_ENDED_WITH_EOL_ERROR = "Multipart: Part must be ended with EOL.";
    public const string MULTIPART_PART_IS_ALREADY_REGISTERED_ERROR = "Multipart: Part with the name {0} is already registered.";
    public const string MULTIPART_PART_EMPTY_NAME_ERROR = "Multipart: Name of part couldn't be null or empty.";
    public const string MULTIPART_NO_LF_NOR_CRLF_ISNT_FOUND_ERROR = "Neither \\r\\n nor \\n are found. Invalid multipart stream.";
    public const string MULTIPART_BOUNDARY_MISMATCH_ERROR = "Multipart: Boundary from stream doesn't match expected boundary.\r\nExpected=\"{0}\".\r\nActual=\"{1}\".";
    public const string MULTIPART_BOUNDARY_COULDNT_BE_SHORTER_3_ERROR = "Multipart: Boundary couldn't be shorter than 3 chars.";
    public const string MULTIPART_BOUNDARY_IS_TOO_SHORT = "Multipart: Full boundary is too short.";
    public const string MULTIPART_BOUNDARY_SHOULD_START_WITH_HYPHENS = "Multipart: Boundary should start with double hyphen.";
    public const string MULTIPART_TERMINATOR_ISNT_FOUND_ERROR = "Multipart: Terminator isn't found.";
    public const string MULTIPART_PART_SEGMENT_ISNT_TERMINATED_CORRECTLY_ERROR = "Multipart isn't terminated with {0}.";
    public const string MULTIPART_STREAM_NOT_NULL_MUST_SUPPORT_READ_ERROR = "Multipart: Stream couldn't be null and must support read operation.";
    public const string MULTIPART_STREAM_NOT_NULL_MUST_SUPPORT_WRITE_ERROR = "Multipart: Stream couldn't be null and must support write operation.";
    public const string MULTIPART_SPECIFIED_BOUNDARY_ISNT_FOUND_ERROR = "Specified boundary not found. Invalid multipart stream.";

    public const string GEO_LOOKUP_SVC_CANCELED_ERROR =
          "GEO lookup service start canceled";

    public const string MAILER_SINK_IS_NOT_SET_ERROR = "Mailer sink is not set";
    public const string MESSAGE_SINK_IS_NOT_OWNED_ERROR = "The message sink being set is not owned by this service";
    public const string SENDING_MESSAGE_HAS_NOT_SUCCEEDED = "Sending message on sink '{0}' has not succeeded";

    public const string MAILER_SINK_SMTP_IS_NOT_CONFIGURED_ERROR = "SMTP Mailer sink is not configured: ";

    public const string FS_SESSION_BAD_PARAMS_ERROR =
      "Can not create an instance of file system session '{0}'. Make sure that suitable derivative of FileSystemSessionConnectParams is passed for the particular file system";

    public const string DELETE_MODIFY_ERROR = "Can not modify field value while in deleting operation. Field <{0}>";

    public const string HTTP_OPERATION_ERROR = "HTTP[S] error: ";

    public const string CLOUD_SYSTEM_DUPLICATE_NAME_ERROR = "Can not have cloud system instance of type '{0}' with the name '{1}' as this name is already registered.";

    public const string CLOUD_SYSTEM_DUPLICATE_HOST_ERROR = "Can not add instance of type '{0}' with the name '{1}' as this name is already registered in cloud system {2}.";
  }
}
