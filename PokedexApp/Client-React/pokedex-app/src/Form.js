import { useState } from 'react';
import useFetch from './useFetch';
import PokemonInfo from './PokemonInfo';

//component for searching pokemons
//on submit calls handleSubmit in useFetch.js whit input value
//to get the data back it calles useFetch
//PokemonInfo shows the result and here the data is passed to do that as props
const Form = () => {
    const [input, setInput] = useState('');
    const { pokemonInfo, error, isPending, handleSubmit } = useFetch();

    return (
        <div className="formSearch">
            <p>Hitta din favorit pokemon...</p>
            <form
                className="d-flex justify-content-center searchBox"
                role="search"
                onSubmit={(e) => handleSubmit(e, input)}
            >
                <input
                    className="me-2 w-40 large-input"
                    type="text"
                    required
                    placeholder="Sök pokemon..."
                    value={input}
                    onChange={(e) => setInput(e.target.value)}
                />
                <button className="btn btn-primary">Sök</button>
            </form>

            <PokemonInfo pokemonInfo={pokemonInfo} error={error} isPending={isPending}/>
        </div>
    );
};

export default Form;
