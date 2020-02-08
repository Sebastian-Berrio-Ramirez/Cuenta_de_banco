using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AccountManager : MonoBehaviour
{
    int currentIndexAccounts;
    double valorqueResta;
    double valorQueSuma;
    public InputField nombre;
    public InputField otroValorRetiro;
    public InputField saldoInicial;
    public Text titular;
    public Text saldo;
    public Text eliminar;
    public Text advertencia;
    Dictionary<string, Cuenta> dicCuentas = new Dictionary<string, Cuenta>();


    public void CrearCuenta()
    {
        if (!string.IsNullOrEmpty(nombre.text) && !string.IsNullOrEmpty(saldoInicial.text))
        {
            Cuenta NuevaCuenta = new Cuenta(nombre.text, System.Convert.ToDouble(saldoInicial.text));
            dicCuentas.Add(NuevaCuenta.getTitular(), NuevaCuenta);
            currentIndexAccounts++;
            titular.text = NuevaCuenta.getTitular();
            string tempSaldo = NuevaCuenta.getCantidad().ToString();
            saldo.text = tempSaldo;
        }
        else if (!string.IsNullOrEmpty(nombre.text))
        {
            Cuenta NuevaCuenta = new Cuenta(nombre.text);
            dicCuentas.Add(NuevaCuenta.getTitular(), NuevaCuenta);
            currentIndexAccounts++;
            titular.text = NuevaCuenta.getTitular();
            string tempSaldo = NuevaCuenta.getCantidad().ToString();
            saldo.text = tempSaldo;
        }
        eliminar.text = "";
    }

    public void ConsultarCuenta()
    {
        Cuenta NuevaCuenta = dicCuentas[nombre.text];
        titular.text = NuevaCuenta.getTitular();
        saldo.text = NuevaCuenta.getCantidad().ToString();
        eliminar.text = "";
    }

    public void Retirar()
    {
        Cuenta NuevaCuenta = dicCuentas[nombre.text];
        valorqueResta = System.Convert.ToDouble(otroValorRetiro.text);
        NuevaCuenta.Retirar(valorqueResta);
        saldo.text = NuevaCuenta.getCantidad().ToString();
    }

    public void Ingresar()
    {
        Cuenta NuevaCuenta = dicCuentas[nombre.text];
        valorQueSuma = System.Convert.ToDouble(otroValorRetiro.text);
        NuevaCuenta.Ingresar(valorQueSuma);
        saldo.text = NuevaCuenta.getCantidad().ToString();
    }

    public void BorrarCuenta()
    {
        Cuenta NuevaCuenta = dicCuentas[nombre.text];
        dicCuentas.Remove(nombre.text);
        eliminar.text = "se borro su cuenta con exito";
        titular.text = " ";
        saldo.text = " ";
        advertencia.text = "Si su cuenta tenia dinero a la hora de ser borrada, pues que lastima pero esa platica se perdio";
    }
}

/*crear un funcion con el onclick para guardar la información de la cuenta como 
  unanueva y otra funciona que muestra la información de una de las cuentas*/


/* En la siguiente línea guardo en una varibale float llamada "temporal" la conversión a flotante (Tosingle) del texto tipo string 
ingresado en el input field "saldoInicial"; la conversión se hace a través del namespace System, usando la clase convert, llamando 
el metodo ToSingle y dando en los argumentos el atributo a convertir. PD: para convertir a un double se usa ToDouble
"float temporal = System.Convert.ToSingle(saldoInicial.text);" */

/* Anotación 1:
Recordar la sintaxis de un array:
nombre del tipo de atributo o clase del que se va a hacer una array, corchetes, nombre del array igual (igualdad =) a new tipo de 
clase o atributo del que estoy haciendo un array y en los ultimos corchetes la cantidad de datos en el array */

/* Anotacion 2: 
Una solución efectiva cuando no permite usar inputfield.text (nombre.text en este caso) es usar una variable string (EstaCuenta) 
y asignarle el valor del input field, luego utilizar el setter de la cuenta instanciada (NuevaCuenta.Set())para asignarle el nombre 
que se guardó en el string "EstaCuenta", sin embargo usamos el constructor para iniciarlizar el valor */

/*string.IsNullOrEmpty(string);*/
