# PriorityQueue
A plugin to allow a list of non-administrators logging into full servers on V-Rising.

List of steam64 ids are stored in: 
`\SERVER_FOLDER\BepInEx\config\PriorityQueue`

Each steam64 id is stored inside `priorityusers.json` with the following format:
```json
{
  "priorityUsers": [
    "12345678910121314",
    "41312101987654321"
  ]
}
```

<details>
<summary><strong>Ingame Commands</strong></summary>

  
- `.priority add steam64id`
  - Add a new user to the priority list
- `.priority remove steam64id`
  - Remove existing user from the priority list
- `.priority list`
  - Output all steam64 ids populated in the list.
</details>

## Dependencies
- [VampireCommandFramework](https://thunderstore.io/c/v-rising/p/deca/VampireCommandFramework/) by Deca.

## Credits

- [Deca](https://github.com/deca) for VampireCommandFramework.
- [V Rising Modding Community](https://vrisingmods.com) for helping out with questions.

## License

This project is licensed under the GPL-3.0 license.
