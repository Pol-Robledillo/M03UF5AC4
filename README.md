# M03UF5AC4
## Fuentes
- Raquel Alamán Navas. (2024, 23 abril). bloc-programacio. Repositori Programació. ([Repositori de Programació](https://github.com/RaquelAlamanITB/bloc-programacio/blob/main/README.md?authuser=3))
- Raquel Alamán Navas. (2024, 23 abril). M03 UF5 Teoría. UF5. POO. Classes fonamentals i 
persistència en BD. M03.UF5. [Teoria](https://docs.google.com/document/d/1JJhB0bqxqns69wKZyF-s8eacxkzv55gO-ez6QvXEvhw/edit#heading=h.4heg8liyhxx)
- Pol Robledillo. (2024, 23 abril). M03UF5AC3. ([Repositori AC3](https://github.com/Pol-Robledillo/M03UF5AC3))
## IAs
Prompt:
~~~
public bool IsHighestDomCons(double cons)
~~~
Respuesta(Copilot):
~~~
{
    ConsumDAO consumDAO = new ConsumDAO(NpgsqlUtils.OpenConnection());
    List<ConsumDTO> consums = consumDAO.GetAll();
    double highestCons = consums.Max(x => x.ConsumDomesticPerCapita);
    return cons == highestCons;
}
~~~
