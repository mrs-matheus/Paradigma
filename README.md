
# Paradigma Arvore

Aplicação console para resolver desafio técnico.

---

## Tecnologias Utilizadas

- .NET Core 9 (Console Application)
- C#

---

## Como Rodar

1. Clone este repositório:
   ```bash
   git clone https://github.com/mrs-matheus/Paradigma.git
   ```
2. Entre na pasta do projeto:
   ```bash
   cd Paradigma
   ```
3. Execute o projeto:
   ```bash
   dotnet run
   ```

---

## Funcionalidades Principais

- Validação de inputs do usuário utilizando expressões regulares (Regex) para aceitar somente o formato esperado.
- Uso de `HashSet` para evitar duplicação de valores.
- Utilização de funções estáticas para montar e exibir a árvore de forma visual no console.

---

## Exemplo de Uso

**Entrada (exemplo):**
```
Digite os números para montar a árvore (ex: 4,2,6,5,50,37,12,32,11,14,21): 4,2,6,5,50,37,12,32,11,14,21

```

**Retorno Esperada:**
```
 Informações da árvore:

Array de entrada: [4, 2, 6, 5, 50, 37, 12, 32, 11, 14, 21]

Raiz: 50

Galhos a esquerda: 6, 5, 4, 2

Galhos a direita: 37, 32, 21, 14, 12, 11


Árvore visual:

                                       50
                                      /   \
                                    6      37
                                  /           \
                                5              32
                              /                   \
                            4                      21
                          /                           \
                        2                              14
                                                          \
                                                           12
                                                              \
                                                               11
```

**Bonus**
Adicionei também o retorno do objeto em formato json;

```
Objeto em formato JSON:

{
  "RootValue": 50,
  "LeftBranches": [
    {
      "Value": 6
    },
    {
      "Value": 5
    },
    {
      "Value": 4
    },
    {
      "Value": 2
    }
  ],
  "RightBranches": [
    {
      "Value": 37
    },
    {
      "Value": 32
    },
    {
      "Value": 21
    },
    {
      "Value": 14
    },
    {
      "Value": 12
    },
    {
      "Value": 11
    }
  ]
}

```

---

## Observações

Este projeto é um exemplo prático para o desafio técnico, focando em qualidade de código, validação robusta e visualização da estrutura de dados.

---

## Autor

Matheus Reis dos Santos
