# projeto_Calculadora-CSharp
Calculadora desenvolvida utilizando Windows Forms e C#. 

## Autor
- [@vitor-matheus1999](https://www.github.com/vitor-matheus1999)

## Apêndice
Para utilizar a calculadora é preciso realizar o download do arquivo completo e seguir o caminho:
bin\Debug\net6.0-windows
Em seguida selecionar o arquivo executável "Calculadora".

## Features
- Reiniciar a calculadora;
- Realizar cálculos contínuos apenas clicando nos operadoradores matemáticos;
- Excluir zero a esquerda;
- Substituir o número zero caso aja apenas esse número na cálculadora;
- Apresentar mensagem de erro de divisão por zero.

## Disclairmer
<i> Primeiramente, o código apresenta de forma "pouco produtiva" a maneira com que poderia ser criado os métodos, funções, propriedes e atributos. A criação de uma classe que tratasse as funcionalidades e exceções da calculadora, tornaria o código "mais limpo" no arquivo "Form1.cs". Porém, por conta do tempo em que tive para construir esse projeto, acabei focando em construir todo o código  nesse unico arquivo e explicar aqui no "Readme" de forma mais minuciosa.<i>

---

## Sobre o projeto

  Esse projeto foi um exercício proposto por um professor da faculdade que estou cursando. O foco desse projeto é a construção de uma calculadora simples que possa realizar equações matemáticas de soma, subtração, múltiplicação e divisão. Sendo também tratado as possíveis exceções e erros, que serão mais detalhados no decorrer do Read.md, que podem vir a ocorrer quando a calculadora for utilizada.

## Breve apresentação da calculadora

A calculadora segue um design simples, seguindo o exemplo da calculadora padrão utilizado pelo sistema Windows:
<div>
  <img width='400em' src="imgCalculadora/imgCalculadora.JPG">
</div>
Porém, a calculadora que é utilizada pelo windows contém o botão que insere "virgula"/"ponto" para expressar um número decimal na equação, botão esse que não contém em minha calculadora. Todavia, ire inserir o botão em versões futuras do projeto para deixar a calculadora mais "completa".

No total, a calculadora possui 16 botões:
* Sendo 10 deles números inteiros de 0 a 9, para  montar o valor das variáveis tratadas nos cálculos;
* 4 botões referentes aos operadores matemáticos de soma (+), subtração (-), múltiplicação (*) e divisão (/);
* 1 botão de igual para representar o resultado obtido pelo cálculo realizado;
* 1 botão "AC" ou "All Clear" para reiniciar a calculadora.

Em cima dos botões, o display atuará por apresentar os números e resultador obtidos pela calculadora.

Para que os números sejam lidos, e os cálculos realizados, é preciso que o usuário clique nos botões que constam na calculadora. Clicando nos números com o mouse, a cálculadora apresentará em seu display o número desejado pelo usuário.

## Sobre o código e a lógica utilizada 

A lógica de uma calculadora simples é básica. Primeiramente, precisamos entender como funciona um cálculo matemático simples: é preciso reunir no mínimo duas variáveis que serão os nossos operandos, em seguida pegaremos um operador matemático para definir o tipo de cálculo que será realizado e, por fim, realizar a conta para então apresentar o resultado obtido.

Agora, tendo a lógica em mente poderemos começar a utilizar o C# para construir a calculadora.

### Porém, por onde podemos começar?

Podemos começar construindo a maneira em que trabalharemos com os operandos. Primeiramente, os operandos irão trabalhar como variáveis na calculadora simples e como dito anteriormente, é preciso no mínimo dois operandos para gerar um cálculo. Assim, como será necessário armazenar duas variáveis diferentes, poderemos utilizar um array uni-dimensional de duas posições para armazenar esses dois valores:

```cs
 public string[] valor = new string[2];
```

 E como será preciso alterar entre essas duas posições será criado um atríbuto para passar em que posição o array deve estar quando necessário:

 ```cs
 public int posicaoArray = 0;
```

O motivo do array ser uma variável do tipo "String", é por conta de que as variáveis que estarão sendo trabalhadas precisão ser apresentadas no display (que é um "textBox") que trabalha unicamente com texto. Outra dúvida possível é: 

### Por que será criado um array com apenas duas posições se um cálculo matemático pode ter mais de dois operandos?

Para responder essa questão será preciso entender a maneira com que a lógica para trabalhar com os resultados dos cálculos foi pensada:

Como é preciso no mínimo duas variáveis para construir um cálculo matemático podemos fazer com que apenas duas variáveis sejam necessário para trabalhar com múltiplos operandos.Para isso o array criado receberá dois valores que atuarão como operandos do cálculo matemático, funcionando do seguinte modo:

***posição 0 do array*** (operador matemático) ***posição 1 do array***  

Em seguida, com o resultado obtido o valor será passado para a primeira posição (ou posição 0) e apresentado no display, já o valor na segunda posição (ou posição 1) será zerado para que sejá possível inserir um novo valor e realizar um novo cálculo matemática utilizando o resultado obtido anteriormente. Diante do exposto, é possível concluir que:

- Não existe necessidade de se fazer uma lista com múltiplos operandos, pois com apenas dois é possível tratar essa possibilidade fazendo com que sejá inserido um novo operando de cada vez na segunda posição (ou posição 1) preservando o resultado obtido anteriormente na primeira posição (ou posição 0), gerando assim um "looping" de cálculos.

 O código a seguir exemplifica o que foi explicado anteriormente:
 ```cs
case "+":
                    resultado = Int64.Parse(this.valor[0]) + Int64.Parse(this.valor[1]); // valor na primeira e segunda posição realizando o cálculo
                    this.valor[0] = resultado.ToString(); // o resultado segue para a primeira posição
                    this.valor[1] = "0"; // é zerado a segunda posição
                    textBox1.Text = this.valor[0]; // Por fim é apresentado o resultado, que está nesse momento está na primeira posição.
                    break;
```













