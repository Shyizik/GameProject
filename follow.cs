using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// —крипт, що змушуЇ об'Їкт (наприклад, камеру або св≥тло) сл≥дувати за ≥ншим об'Їктом (Sprite)
public class follow : MonoBehaviour
{
    // ќб'Їкт, за €ким потр≥бно стежити (перет€гуЇтьс€ у ≥нспектор≥)
    [SerializeField] private Transform Sprite;

    // Start викликаЇтьс€ один раз на початку (не використовуЇтьс€ тут)
    void Start()
    {
        
    }

    // Update викликаЇтьс€ кожен кадр
    void Update()
    {
        // «м≥нюЇмо позиц≥ю об'Їкта, на €кому висить цей скрипт, щоб сл≥дувати за Sprite по X та Y.
        // Z-координата залишаЇтьс€ незм≥нною (щоб не зламати, наприклад, положенн€ камери)
        transform.position = new Vector3(Sprite.position.x, Sprite.position.y, transform.position.z);
    }
}
