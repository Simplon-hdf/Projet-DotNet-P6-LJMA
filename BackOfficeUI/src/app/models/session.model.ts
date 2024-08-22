export interface Session {
    id?: string;
    nom: string;
    date_debut: Date;
    date_fin: Date;
    randonneeId: string; 
    themeId: string;
  }