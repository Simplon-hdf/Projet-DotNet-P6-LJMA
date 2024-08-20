export interface Randonnee {
    id?: string; // Utilisez string si l'ID est une chaîne
    desc: string;
    image: string;
    lieu: string;
    limite_participant: number;
    nb_jour: number;
    nb_nuit: number;
    prix: number;
}