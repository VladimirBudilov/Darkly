using exploinator;

Validator.ValidateArgs(args);
var ipAddress = args[0];
Validator.ValidateIpAddress(ipAddress);
Exploinator.DoWork(ipAddress).Wait();



