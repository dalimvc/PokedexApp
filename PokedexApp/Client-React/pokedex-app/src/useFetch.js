import { useState } from 'react';

//custom hook that will be used to fetch the data from the backend
//useState is used to set values for the data that will be displayed
//handleSubmit is called in the Form on submition
//different values will be set based on success or faliour of the fetch
//it will return values that are displayed
const useFetch = () => {
    const [pokemonInfo, setPokemonInfo] = useState(null);
    const [error, setError] = useState(null);
    const [isPending, setIsPending] = useState(false);

    async function handleSubmit(e, input) {
        e.preventDefault();
        setIsPending(true);
        const url = `https://localhost:7037/Pokemon/${input}`;
        try {
            
            const response = await fetch(url);
            if (!response.ok) {
                throw new Error(`${response.status}`);
            }

            const result = await response.json();
            setPokemonInfo(result);
            setError(null);
            setIsPending(false);
            console.log(result);
        } catch (error) {
            console.error("eee. " + error.message);
            if (error.message === '404') {
                setPokemonInfo(null);
                setIsPending(false);
                setError('Det gick inte att hitta pokemonen.');
            }
        }
    }

    return { pokemonInfo, error, isPending, handleSubmit };
}

export default useFetch;
