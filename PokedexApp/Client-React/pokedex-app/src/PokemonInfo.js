//it displays pokemon details after fetching data
const PokemonInfo = ({ pokemonInfo, error, isPending }) => {
    return ( 
        <div className="pokemon-info"> 
            {isPending && <div><p>Laddar...</p></div>}

            {pokemonInfo && 
            <div>
                <h2>Pokemon {pokemonInfo.name}</h2>
                <img src={pokemonInfo.image} alt={pokemonInfo.name} />
            </div>}
            {error && <div className="error"><p>{error}</p></div>}
        </div>
     );
}
 
export default PokemonInfo;