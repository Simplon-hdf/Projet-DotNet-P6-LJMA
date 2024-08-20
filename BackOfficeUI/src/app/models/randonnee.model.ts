export interface Randonnee {
    // id : number,
    // nom: string,
    // participant: number,
    // nuit: number,
    // lieu: string,
    // prix: number,
    // sessions : Session[]
    id?: string; // Utilisez string si l'ID est une chaîne
    desc: string;
    image: string;
    lieu: string;
    limite_participant: number;
    nb_jour: number;
    nb_nuit: number;
    prix: number;
}

interface Session {
    id: number;
    nom: string;
    dateDebut: string;
    dateFin: string;
    randonneeId: number;
    themeId: number;
  }