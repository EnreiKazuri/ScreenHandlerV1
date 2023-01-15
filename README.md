# ScreenHandlerV1

Proof of concept of a ScreenHandler api, which creates console menus based on a json given to it by the user

Screen structure
```json
{
 "ID": "StartScreen",
 "EntryPoint": true,
 "Title": "Bienvenido!",
 "Message": "Como estan todos! (E) para continuar!",
 "Fields": null,
 "Actions": [{ "Name": "Seguir", "Option": "e", "Handler": "NextScreen", "NextScreen": "FollowUpScreen"}]
}
```

EntryPoint
> There should only be a single entry point between all screens, if there are multiple, the app will choose the first one it finds to display.

Message and Field
> A screen cannot have both message and fields, as they both serve to display a message in different ways, if both are present, the message will take priority, and fields will not be displayed.

Actions
> Both the Option property and the Handler property are case insensitive, but the NextScreen property is, so be careful.
