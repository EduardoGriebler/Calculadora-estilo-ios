# 📱 Calculadora Estilo iPhone

Este projeto é uma calculadora funcional para Windows, desenvolvida em C# utilizando o framework Windows Forms, com design inspirado na calculadora do iOS.

## Visual do Projeto

![Image](https://github.com/user-attachments/assets/a43626df-0282-44e4-87c1-bde0c912d8d1)

---

### Status do Projeto

**Finalizado (Versão 1.0)**

- [x] Interface visualmente parecida ao design da calculadora do iPhone.
- [x] Remover os botões de (fechar, maximizar e minimizar) e implementar novos customizados.
- [x] Interface com display duplo.
- [x] Implementa lógica dos botões de controle da janela (fechar, maximizar e minimizar).
- [x] Implementa lógica no painel superior para poder arrastar a tela.
- [x] Implementa lógica na calculadora para sempre começar mostrando "0" no display principal.
- [x] Implementa lógica nos botões de fechar, maximizar e minimizar mudam de cor quando o mouse passa por cima (efeito hover).
- [x] Após finalizar um cálculo com "=", se você digitar um novo número ou vírgula, a calculadora limpa automaticamente os displays.
- [x] Impede a digitação de múltiplos zeros no início (não deixa digitar "00").
- [x] Permite adicionar uma vírgula apenas se o número atual que está sendo digitado ainda não tiver uma (permite corretamente 10,5 + 5,2).
- [x] Detecta a tentativa de divisão por zero, exibe "Indefinido" no display principal e impede que o cálculo continue.
- [x] Utiliza blocos try-catch para capturar erros que podem ocorrer se o usuário digitar uma expressão inválida (ex: 10 + =), mostrando "Erro" em vez de fechar o programa.

### Tecnologias Utilizadas

* **Linguagem:** C#
* **Framework:** .NET Framework com Windows Forms
* **IDE:** Visual Studio
* **Controle de Versão:** Git e GitHub